using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        internal async void HandleHotkey(IntPtr wParam, bool enable)
        {
            foreach (GameCheat gameCheat in trainer.GameCheats)
            {
                if (gameCheat.Hotkey.Value.Equals(wParam.ToString()))
                {
                    string jsonstring1 = "{\"parameters\": { \"start\" : 0x09000000, \"end\" : 0x0A000000, \"search\" : \"89 88 DC 00 00 00 8B 88\", \"writable\" : true, \"executable\" : true, \"file\": \"\" }}";
                    JObject json1 = JsonConvert.DeserializeObject<JObject>(jsonstring1);

                    var signature = new[] { typeof(long) , typeof(long) , typeof(string) , typeof(bool) , typeof(bool) , typeof(string) };
                    var method1 = memLib.GetType().GetMethod("AoBScan", signature);
                    object[] param1 = method1.GetParameters()
        .Select(p => Convert.ChangeType((string)json1["parameters"][p.Name], p.ParameterType))
        .ToArray();

                    Task<IEnumerable<long>> scanTask = (Task<IEnumerable<long>>) method1.Invoke(memLib, param1);
                    await scanTask;
                    IEnumerable<long> scanLong = scanTask.Result;
                    string scan = scanLong.FirstOrDefault().ToString("x8").ToUpper();

                    string jsonstring2 = "{\"parameters\": { \"address\" : \" \", \"type\" : \"bytes\", \"value\" : \"0x90 0x90 0x90 0x90 0x90 0x90\" }}";
                    JObject json2 = JsonConvert.DeserializeObject<JObject>(jsonstring2);

                    var method2 = memLib.GetType().GetMethod("FreezeValue");
                    object[] param2 = method2.GetParameters()
        .Select(p => Convert.ChangeType((string)json2["parameters"][p.Name], p.ParameterType))
        .ToArray();
                    param2[0] = scan;
                    method2.Invoke(memLib, param2);

                    string jsonstring3 = "{\"parameters\": { \"address\" : \"libhl.dll+0x0002D1A8,0x448,0x8,0x58,0x64,0xD8\", \"type\" : \"int\", \"value\" : \"999999\", \"file\": \"\" }}";
                    JObject json3 = JsonConvert.DeserializeObject<JObject>(jsonstring3);

                    var method3 = memLib.GetType().GetMethod("FreezeValue");
                    object[] param3 = method3.GetParameters()
        .Select(p => Convert.ChangeType((string)json3["parameters"][p.Name], p.ParameterType))
        .ToArray();

                    method3.Invoke(memLib, param3);

                    string jsonstring4 = "{\"parameters\": { \"address\" : \"libhl.dll+0x0002D1A8,0x580,0x0,0x18,0x64,0xDC\", \"type\" : \"int\", \"value\" : \"999999\", \"file\": \"\" }}";
                    JObject json4 = JsonConvert.DeserializeObject<JObject>(jsonstring4);

                    var method4 = memLib.GetType().GetMethod("FreezeValue");
                    object[] param4 = method4.GetParameters()
        .Select(p => Convert.ChangeType((string)json4["parameters"][p.Name], p.ParameterType))
        .ToArray();

                    method4.Invoke(memLib, param4);

                    /*long scan = memLib.AoBScan(0x09000000, 0x0A000000, "89 88 DC 00 00 00 8B 88", true, true).Result.FirstOrDefault();
                    memLib.FreezeValue(scan.ToString("x8").ToUpper(), "bytes", "0x90 0x90 0x90 0x90 0x90 0x90");
                    memLib.FreezeValue("libhl.dll+0x0002D1A8,0x448,0x8,0x58,0x64,0xD8", "int", "999999");
                    memLib.FreezeValue("libhl.dll+0x0002D1A8,0x580,0x0,0x18,0x64,0xDC", "int", "999999");
                    */
                }
            }
        }
    }
}
