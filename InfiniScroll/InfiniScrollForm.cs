using System.Windows.Forms;

namespace InfiniScroll
{
    public partial class InfiniScrollForm : Form
    {
        private readonly InfiniScroller _scroller;

        public InfiniScrollForm(InfiniScroller scroller)
        {
            _scroller = scroller;
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == InfiniScroll.ToggleHotKey)
            {
                if (InfiniScroller.IsOn())
                {
                    _scroller.ToggleOff();
                }
                else
                {
                    _scroller.ToggleOn();
                }
            }

            base.WndProc(ref m);
        }
    }
}
