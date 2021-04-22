using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace OpenTrainerProject.Components
{
    public partial class StartView : UserControl
    {
        public StartView()
        {
            InitializeComponent();

            // Fetch Trainers from API in background thread
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += fetchTrainers;
            worker.RunWorkerCompleted += fetchTrainersCompleted;
            worker.RunWorkerAsync();
        }

        private void fetchTrainers(object sender, DoWorkEventArgs e)
        {
            //
        }
        private void fetchTrainersCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //
        }
        // Change window content
        private void ProceedButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Window.GetWindow(this);
            window.WindowContent = new TrainerView();
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

        private void GameComboBox_DropDownClosed(object sender, EventArgs e)
        {
            //
        }
    }
}
