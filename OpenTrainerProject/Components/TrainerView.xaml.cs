using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Memory;

namespace OpenTrainerProject.Components
{
    /// <summary>
    /// Interaction logic for TrainerView.xaml
    /// </summary>
    public partial class TrainerView : UserControl
    {
        public TrainerView()
        {
            InitializeComponent();
        }
        public Mem MemLib = new Mem();
        bool gameProc = false;

        private void ProceedButton_Click(object sender, RoutedEventArgs e)
        {
            gameProc = MemLib.OpenProcess("explorer");
            if (gameProc)
            {
                TitleBar.TitleText = "Found Explorer.exe";
                MemLib.OpenProcess("explorer");
            }
            else
            {
                TitleBar.TitleText = "Game Not Found";
            }
        }

        private void GithubButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/anfeichtinger/open-trainer-project");
        }
        private void DonateButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.paypal.com/donate/?hosted_button_id=EE3W7PS6AHEP8");
        }
    }
}
