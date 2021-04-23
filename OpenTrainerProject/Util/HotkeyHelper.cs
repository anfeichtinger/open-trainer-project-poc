using OpenTrainerProject.Components;
using OpenTrainerProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace OpenTrainerProject.Util
{
    class HotkeyHelper
    {
        private TrainerView obj;

        public HotkeyHelper(TrainerView obj)
        {
            this.obj = obj;
        }

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public void RegisterHotkeys(Hotkey[] hotkeys)
        {
            Window window = System.Windows.Window.GetWindow(obj);
            var source = PresentationSource.FromVisual(window as Visual) as HwndSource;
            if (source == null)
                throw new Exception("Could not create hWnd source from window.");
            source.AddHook(obj.WndProc);

            var helper = new WindowInteropHelper(window);
            foreach (Hotkey hotkey in hotkeys)
            {
                int value = int.Parse(hotkey.Value);
                Console.WriteLine(RegisterHotKey(helper.Handle, value, 0x0000, value));
            }
        }
        
    }
}
