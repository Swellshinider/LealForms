using LealForms.UI.Utils;
using LealForms.UI.Utils.Extensions;

namespace LealForms.UI.Forms
{
    public partial class LealBorderlessForm : LealBaseForm
    {
        private const int cGrip = 16;

        public LealBorderlessForm()
        {
            InitializeComponent();
        }

        public override void InitializeObjects()
        {
            LealBorderlessForm_Resize(null, EventArgs.Empty);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                var position = new Point(m.LParam.ToInt32());
                position = PointToClient(position);

                if (position.X >= ClientSize.Width - cGrip && 
                    position.Y >= ClientSize.Height - cGrip)
                {
                    m.Result = Constants.HTBOTTOMRIGHT;
                    return;
                }
                else if (position.X >= ClientSize.Width - cGrip)
                {
                    m.Result = Constants.HTRIGHT;
                    return;
                }
                else if (position.Y >= ClientSize.Height - cGrip)
                {
                    m.Result = Constants.HTBOTTOM;
                    return;
                }
            }

            base.WndProc(ref m);
        }

        private void LealBorderlessForm_Resize(object? sender, EventArgs e) 
            => Region = this.GenerateRoundRegion(Width, Height, 15);
    }
}