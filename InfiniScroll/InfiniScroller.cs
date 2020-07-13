using System.Runtime.InteropServices;
using System.Threading;

namespace InfiniScroll
{
    public class InfiniScroller
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, int dwExtraInfo);

        private static bool _isOn = false;

        public static bool IsOn()
        {
            return _isOn;
        }

        public void ToggleOn()
        {
            if (_isOn)
            {
                return;
            }

            _isOn = true;

            var thread = new Thread(StartScrollLoop);
            thread.Start();
        }

        private static void StartScrollLoop()
        {
            while (_isOn)
            {
                mouse_event(0x0800, 0, 0, 120, 0);

                Thread.Sleep(10);
            }
        }

        public void ToggleOff()
        {
            if (!_isOn)
            {
                return;
            }

            _isOn = false;
        }
    }
}
