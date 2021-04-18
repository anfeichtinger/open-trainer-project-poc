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

namespace OpenTrainerProject
{

    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) {
                DragMove();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public Mem MemLib = new Mem();
        bool gameProc = false;
        private void ProceedButton_Click(object sender, RoutedEventArgs e)
        {
            gameProc = MemLib.OpenProcess("explorer");
            if (gameProc)
            {
                WindowTitle.Text = "Found Explorer.exe";
                MemLib.OpenProcess("explorer");
            }
            else 
            {
                WindowTitle.Text = "Open Trainer Project";
            }
        }
    }
}
