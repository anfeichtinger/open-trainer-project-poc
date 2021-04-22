using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace OpenTrainerProject.Components
{
    public partial class TrainerView : UserControl
    {
        public TrainerView()
        {
            InitializeComponent();
            TitleBar.WindowTitle.Text = "Game Name Here";
            TitleBar.WindowImage.Source = new BitmapImage(new System.Uri("../Images/ArrowLeftIcon.png", System.UriKind.Relative));
            TitleBar.WindowButton.Cursor = Cursors.Hand;
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
