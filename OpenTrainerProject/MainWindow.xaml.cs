using OpenTrainerProject.Components;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace OpenTrainerProject
{


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private UserControl _WindowContent;
        public event PropertyChangedEventHandler PropertyChanged;
        public UserControl WindowContent 
        { 
            get { return _WindowContent; } 
            set { 
                _WindowContent = value; 
                OnPropertyChanged(); 
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public MainWindow()
        {
            InitializeComponent();
            WindowContent = new StartView();
        }

    }
}
