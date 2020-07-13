using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace InfiniScroll
{
    public class HotKeyListener
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private readonly InfiniScrollForm _form;

        public HotKeyListener(InfiniScrollForm form)
        {
            _form = form;
            RegisterHotKey(form.Handle, InfiniScroll.ToggleHotKey, 0, (int) Keys.F6);
        }

        ~HotKeyListener()
        {
            UnregisterHotKey(_form.Handle, (int) Keys.F6);
            MessageBox.Show("Goodbye!");
        }
    }
}
