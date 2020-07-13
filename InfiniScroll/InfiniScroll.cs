using System;
using System.Runtime.InteropServices;

namespace InfiniScroll
{
    public static class InfiniScroll
    {
        public const int ToggleHotKey = 1;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            var scroller = new InfiniScroller();
            var form = new InfiniScrollForm(scroller);
            _ = new HotKeyListener(form);
            form.ShowDialog();
        }
    }
}
