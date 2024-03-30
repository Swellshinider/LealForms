namespace LealForms.UI.Forms
{
    public partial class LealBaseForm : Form
    {
        // Constructor for LealBaseForm. Sets default UI characteristics for all forms deriving from this base class.
        public LealBaseForm()
        {
            // Set the default background color to white.
            BackColor = Color.White;

            // Set the default font to "Segoe UI" with size 12 and regular font style.
            Font = new Font("Segoe UI", 12, FontStyle.Regular);

            // Enable double buffering to minimize flicker and enhance rendering performance.
            DoubleBuffered = true;

            // Ensure the form is redrawn when it's resized to maintain visual integrity.
            SetStyle(ControlStyles.ResizeRedraw, true);

            // Position the form at the center of the screen by default.
            StartPosition = FormStartPosition.CenterScreen;

            // Placeholder for additional object initialization in derived classes.
            InitializeObjects();
        }

        // Provides an extension point for derived classes to initialize additional objects/components.
        public virtual void InitializeObjects() { }
    }
}