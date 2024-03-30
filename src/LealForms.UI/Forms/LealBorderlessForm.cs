using LealForms.UI.Utils;
using LealForms.UI.Utils.Extensions;

namespace LealForms.UI.Forms
{
    public partial class LealBorderlessForm : LealBaseForm
    {
        // Constant value for defining the grip size for resizing the form.
        private const int cGrip = 16;

        /// <summary>
        /// Constructor for LealBorderlessForm. Calls InitializeComponent to setup components.
        /// </summary>
        public LealBorderlessForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Overridden InitializeObjects method to setup resize behavior specific to LealBorderlessForm.
        /// </summary>
        public override void InitializeObjects()
        {
            // Directly invoke the resize logic to ensure the form's region is properly initialized.
            LealBorderlessForm_Resize(null, EventArgs.Empty);
        }

        /// <summary>
        /// Overrides the window procedure to customize window border behavior, particularly for resizing.
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            // Intercept the window messages to identify mouse position for custom resize handling.
            if (m.Msg == Constants.WM_NCHITTEST)
            {
                var position = new Point(m.LParam.ToInt32());
                position = PointToClient(position);

                // Determine if the mouse position is within the grip area for resizing.
                if (position.X >= ClientSize.Width - cGrip && position.Y >= ClientSize.Height - cGrip)
                {
                    m.Result = Constants.HTBOTTOMRIGHT; // Bottom-right corner grip.
                    return;
                }
                else if (position.X >= ClientSize.Width - cGrip)
                {
                    m.Result = Constants.HTRIGHT; // Right-edge grip.
                    return;
                }
                else if (position.Y >= ClientSize.Height - cGrip)
                {
                    m.Result = Constants.HTBOTTOM; // Bottom-edge grip.
                    return;
                }
            }

            // Call the base class's window procedure for default processing.
            base.WndProc(ref m);
        }

        /// <summary>
        /// Handles form resizing to update the form's region for rounded corners.
        /// </summary>
        private void LealBorderlessForm_Resize(object? sender, EventArgs e)
            => Region = this.GenerateRoundRegion(Width, Height, 15); // Assumes GenerateRoundRegion is implemented elsewhere.
    }
}