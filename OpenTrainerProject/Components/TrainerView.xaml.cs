using Newtonsoft.Json;
using OpenTrainerProject.Model;
using OpenTrainerProject.Util;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace OpenTrainerProject.Components
{
    public partial class TrainerView : UserControl
    {
        private Trainer trainer { get; set; }
        private TrainerHelper helper { get; set; }
        public TrainerView(Trainer trainer)
        {
            this.trainer = trainer;
            InitializeComponent();
            TitleBar.WindowTitle.Text = $"{trainer.GameName} v{trainer.GameVersion} - WAITING FOR GAME";
            TitleBar.WindowImage.Source = new BitmapImage(new Uri("../Images/ArrowLeftIcon.png", System.UriKind.Relative));
            TitleBar.WindowButton.Click += BackButton_Click;

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += fetchTrainer;
            worker.RunWorkerCompleted += fetchTrainerCompleted;
            worker.RunWorkerAsync();
            Mouse.OverrideCursor = Cursors.Wait;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            helper.StopFindGameWorker();
            helper.ClearInstance();
        }

        internal void GameFoundChanged(bool GameFound)
        {
            this.Dispatcher.Invoke(new Action(() => {
                if (GameFound)
                {
                    TitleBar.WindowTitle.Text = $"{trainer.GameName} v{trainer.GameVersion} - GAME FOUND";
                }
                else
                {
                    TitleBar.WindowTitle.Text = $"{trainer.GameName} v{trainer.GameVersion} - WAITING FOR GAME";
                }
            }));
        }

        private void ProceedButton_Click(object sender, RoutedEventArgs e)
        {
            //
        }
        private void fetchTrainer(object sender, DoWorkEventArgs e)
        {
            string json = new ApiHelper().Fetch($"api/trainer/{trainer.Id}");
            if (json.StartsWith("Error"))
            {
                MessageBox.Show(json);
            }
            else
            {
                trainer = JsonConvert.DeserializeObject<Trainer>(json);
            }
        }
        private void fetchTrainerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Mouse.OverrideCursor = null;
            helper = TrainerHelper.GetInstance(trainer, this);
            helper.StartFindGameWorker();
            TitleBar.WindowButton.Cursor = Cursors.Hand;
        }
    }
}
