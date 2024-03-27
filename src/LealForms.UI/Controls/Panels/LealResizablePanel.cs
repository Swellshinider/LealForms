namespace LealForms.UI.Controls.Panels
{
    /// <summary>
    /// A custom UserControl that provides a resizable panel with a visual grip indicator.
    /// This control is designed to be used in Windows Forms applications and includes design-time support
    /// for better integration with the Visual Studio Designer.
    /// </summary>
    public partial class LealResizablePanel : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LealResizablePanel"/> class.
        /// </summary>
        /// <param name="gripSize">The size of the grip area in pixels.</param>
        public LealResizablePanel(int gripSize = 16)
        {
            GripSize = gripSize; // Sets the grip size based on the constructor parameter.
            DoubleBuffered = true; // Enables double buffering to reduce flicker.

            // Ensures the control is invalidated and redrawn when resized, important for the grip drawing.
            SetStyle(ControlStyles.ResizeRedraw, true);

            // Initializes the component, a standard method call for user controls.
            InitializeComponent(); 
        }

        /// <summary>
        /// Gets the size of the grip area.
        /// </summary>
        public int GripSize { get; }

        /// <summary>
        /// Overridden to draw the size grip at the bottom-right corner of the control.
        /// This method is called during the paint event and uses the ControlPaint utility
        /// to draw a standard size grip that visually indicates the resizable area of the control.
        /// </summary>
        /// <param name="e">Provides data for the Paint event.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); // Calls the base class OnPaint method to ensure standard painting operations are performed.

            // Calculates the rectangle area where the size grip is drawn.
            var rect = new Rectangle(ClientSize.Width - GripSize, ClientSize.Height - GripSize, GripSize, GripSize);

            // Draws the size grip within the calculated rectangle, using the control's background color.
            ControlPaint.DrawSizeGrip(e.Graphics, BackColor, rect);
        }
    }
}