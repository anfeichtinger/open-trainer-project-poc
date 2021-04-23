using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenTrainerProject.Model;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using System.Windows.Controls;
using OpenTrainerProject.Util;
using System.Windows.Input;

namespace OpenTrainerProject.Components
{
    public partial class StartView : UserControl
    {
        private Trainer[] Trainers { get; set; }
        public StartView()
        {
            InitializeComponent();

            // Fetch Trainers from API in background thread
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += fetchTrainers;
            worker.RunWorkerCompleted += fetchTrainersCompleted;
            worker.RunWorkerAsync();
            Mouse.OverrideCursor = Cursors.Wait;
        }

        private void fetchTrainers(object sender, DoWorkEventArgs e)
        {
            string json = new ApiHelper().Fetch("api/trainer");
            if (json.StartsWith("[Error]"))
            {
                MessageBox.Show(json);
            } else
            {
                Trainers = JsonConvert.DeserializeObject<Trainer[]>(json);
            }
        }
        private void fetchTrainersCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Trainers != null) 
            { 
                foreach (Trainer trainer in Trainers) 
                {
                    GameComboBox.Items.Add(trainer.GameName);
                }
                GameComboBox.SelectedIndex = 0;
                GameComboBox_DropDownClosed(null, null);
            }

            Mouse.OverrideCursor = null;
        }
        private void GameComboBox_DropDownClosed(object sender, EventArgs e)
        {
            VersionComboBox.Items.Clear();
            if (GameComboBox.Text.Length > 0)
            {
                foreach (Trainer trainer in Trainers)
                {
                    if (trainer.GameName.Equals(GameComboBox.Text))
                    {
                        VersionComboBox.Items.Add(trainer.GameVersion);
                    }
                    VersionComboBox.SelectedIndex = 0;
                }
            }
        }
        // Change window content
        private void ProceedButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            window.WindowContent = new TrainerView(Array.Find<Trainer>(Trainers, (t) => t.GameName == GameComboBox.Text && t.GameVersion == VersionComboBox.Text));
        }
        // Open Github Repo in Browser
        private void GithubButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/anfeichtinger/open-trainer-project");
        }
        // Open Donation Link in Browser
        private void DonateButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.paypal.com/donate/?hosted_button_id=EE3W7PS6AHEP8");
        }
    }
}
