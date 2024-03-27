namespace LealForms.UI.Forms
{
    public partial class LealBaseForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LealBaseForm"/> class with default background color(<see cref="Color.White"/>).
        /// </summary>
        public LealBaseForm()
        {
            // Set the background color of the form.
            BackColor = Color.White;

            // Set base font
            Font = new Font("Segoe UI", 12, FontStyle.Regular);

            // Enable double buffering to reduce flicker and improve rendering performance.
            DoubleBuffered = true;

            // Ensure the form is redrawn when resized.
            SetStyle(ControlStyles.ResizeRedraw, true);

            // Position the form in the center of the screen.
            StartPosition = FormStartPosition.CenterScreen;

            InitializeObjects();
        }

        public virtual void InitializeObjects() { }
    }
}