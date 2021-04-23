using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Memory;
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

        public void ClearInstance()
        {
            _instance = null;
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
    }
}
