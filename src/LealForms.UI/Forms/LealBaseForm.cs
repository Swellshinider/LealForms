using LealForms.UI.Utils.Extensions;

namespace LealForms.UI.Forms
{
    public partial class LealBaseForm : Form
    {
        private bool _titleBarBlackTheme = false;

        /// <summary>
        /// Constructor for LealBaseForm. Sets default UI characteristics for all forms deriving from this base class.
        /// </summary>
        public LealBaseForm()
        {
            // Set the default background and font.
            BackColor = Color.White;
            Font = new Font("Segoe UI", 12, FontStyle.Regular);

            DoubleBuffered = true; // Enable double buffering to minimize flicker and enhance rendering performance.
            SetStyle(ControlStyles.ResizeRedraw, true); // Ensure the form is redrawn when it's resized to maintain visual integrity.

            StartPosition = FormStartPosition.CenterScreen;

            InitializeObjects();
        }

        /// <summary>
        /// Sets the title bar theme
        /// </summary>
        public bool TitleBarBlackTheme
        {
            get => _titleBarBlackTheme;
            set
            {
                Handle.UseImmersiveDarkMode(value);
                _titleBarBlackTheme = value;
            }
        }

        /// <summary>
        /// Provides an extension point for derived classes to initialize additional objects/components.
        /// </summary>
        public virtual void InitializeObjects()
        {
            Text = "LealBaseForm";
            TitleBarBlackTheme = FormExtensions.UseDarkMode();
        }
    }
}