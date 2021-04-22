using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OpenTrainerProject.Components
{
    public partial class TrainerView : UserControl
    {
        public TrainerView()
        {
            InitializeComponent();
        }

        private void ProceedButton_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += fetchTrainer;
            worker.RunWorkerCompleted += fetchTrainerCompleted;
            worker.RunWorkerAsync();
            Mouse.OverrideCursor = Cursors.Wait;
        }
        private void fetchTrainer(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(2000);
        }
        private void fetchTrainerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
        }
    }
}
