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
            TitleBar.WindowButton.Cursor = Cursors.Hand;

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
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri("http://localhost:8000/");

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync($"api/trainer/{trainer.Id}").Result;

            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                trainer = JsonConvert.DeserializeObject<Trainer>(json);
            }
            else
            {
                MessageBox.Show("Error Code" +
                response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }
        private void fetchTrainerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
            helper = TrainerHelper.GetInstance(trainer, this);
            helper.StartFindGameWorker();
        }
    }
}
