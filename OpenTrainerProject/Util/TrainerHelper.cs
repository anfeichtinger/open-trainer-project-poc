using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Interop;
using Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenTrainerProject.Components;
using OpenTrainerProject.Model;

namespace OpenTrainerProject.Util
{
    class TrainerHelper
    {
        private static TrainerHelper _instance = null;
        private static readonly object _mutex = new Object();
        private Trainer trainer;
        private Mem memLib;
        private BackgroundWorker findGameWorker = new BackgroundWorker();
        private TrainerView observer;
        private bool gameFound;
        private int gameProc;
        public bool GameFound { get { return gameFound; } set { gameFound = value; observer.GameFoundChanged(value); } }
        private TrainerHelper(Trainer trainer, TrainerView trainerView)
        {
            this.trainer = trainer;
            this.memLib = new Mem();
            this.observer = trainerView;
            this.GameFound = false;
        }
        public static TrainerHelper GetInstance(Trainer trainer, TrainerView trainerView)
        {
            if (_instance == null)
            {
                lock (_mutex)
                {
                    _instance = new TrainerHelper(trainer, trainerView);
                }
            }
            return _instance;
        }
        public void ClearInstance()
        {
            _instance = null;
        }
        public void StartFindGameWorker()
        {
            if (!findGameWorker.IsBusy)
            {
                findGameWorker.WorkerSupportsCancellation = true;
                findGameWorker.DoWork += findGame_DoWork;
                findGameWorker.RunWorkerAsync();
            }
        }
        public void StopFindGameWorker()
        {
            findGameWorker.CancelAsync();
            memLib.CloseProcess();
        }
        private void findGame_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                gameProc = memLib.GetProcIdFromName(trainer.GameId);
                GameFound = memLib.OpenProcess(gameProc);
                Thread.Sleep(2000);
            }
        }

        public void RegisterHotkeys()
        {
            HotkeyHelper helper = new HotkeyHelper(observer);
            Hotkey[] hotkeys = new Hotkey[trainer.GameCheats.Length];
            for (int i = 0; i < hotkeys.Length; i++)
            {
                hotkeys[i] = trainer.GameCheats[i].Hotkey;
            }
            helper.RegisterHotkeys(hotkeys);
        }

        // Some methods are overloaded. Get the signature from the one you need from Memory.dll and add an if here
        private Type[] getSignature(string methodName)
        {
            if (methodName.Equals("AoBScan"))
            {
                return new Type[] { typeof(long), typeof(long), typeof(string), typeof(bool), typeof(bool), typeof(string) };
            }
            return null;
        }
        private _MethodInfo GetMethodInfo(MemFunction f, Type[] signature, bool active)
        {
            if (active)
            {
                if (f.Method.Equals("FreezeValue"))
                {
                    return memLib.GetType().GetMethod("UnfreezeValue");
                }
            }
            return signature != null
                             ? memLib.GetType().GetMethod(f.Method, signature)
                             : memLib.GetType().GetMethod(f.Method);

        }
        internal async void HandleHotkey(IntPtr wParam)
        {
            foreach (GameCheat gameCheat in trainer.GameCheats)
            {
                if (gameCheat.Hotkey.Value.Equals(wParam.ToString()))
                {
                    // For communication between methods
                    int saveResultFor = 0;
                    dynamic result = null;
                    // Iterate over Fuctions
                    foreach (MemFunction f in gameCheat.MemFunctions)
                    {
                        // Dont overwrite existing save count if it's not reset
                        if (saveResultFor == 0)
                        {
                            saveResultFor = f.SaveResultFor;
                        }
                        // Parse json for easy access to values
                        string jsonString = JsonConvert.SerializeObject(f.Parameters, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                        JObject json = JsonConvert.DeserializeObject<JObject>(jsonString);

                        // Some methods like AoBScan are overloaded. For now it's hard coded, ideally should be extracted from parameters
                        Type[] signature = getSignature(f.Method);

                        // Get Activate or Deactivate Method
                        _MethodInfo method = GetMethodInfo(f, signature, gameCheat.IsActive);

                        // Need to convert Addresses to Long for the AoBScan
                        if (f.Method.Equals("AoBScan"))
                        {
                            json["start"] = Convert.ToInt64(json["start"].ToString(), 16);
                            json["end"] = Convert.ToInt64(json["end"].ToString(), 16);
                        }
                        // Generate parameters of correct type
                        object[] param = method.GetParameters()
                                        .Select(p => Convert.ChangeType((string)json[p.Name], p.ParameterType))
                                        .ToArray();

                        // When there is a result from a prior Method
                        if (result != null)
                        {
                            // Use the result as first parameter
                            param[0] = result;
                            method.Invoke(memLib, param);
                            // If result is no longer needed discard it
                            if (--saveResultFor == 0)
                            {
                                result = null;
                            }
                        }
                        // Should save this result
                        else if (saveResultFor > 0)
                        {
                            // AoBScan requires correct handling of types because it's async
                            if (f.Method.Equals("AoBScan"))
                            {
                                Task<IEnumerable<long>> scanTask = (Task<IEnumerable<long>>)method.Invoke(memLib, param);
                                await scanTask;
                                IEnumerable<long> scanLong = scanTask.Result;
                                result = scanLong.FirstOrDefault().ToString("x8").ToUpper();
                            }
                            else
                            {
                                // Simply save result
                                result = method.Invoke(memLib, param);
                            }
                        }
                        else
                        {
                            // No special case
                            method.Invoke(memLib, param);
                        }
                    }
                    // Set active state accordingly
                    gameCheat.IsActive = !gameCheat.IsActive;
                }
            }
        }
    }
}
