using LealForms.UI.Resources;
using LealForms.UI.Utils.Extensions;
using System.ComponentModel;

namespace LealForms.UI.Controls.Custom
{
    public partial class LealTitleBar : UserControl
    {
        /// <summary>
        /// Indicates whether the title bar is using the black theme.
        /// </summary>
        private bool _blackTheme = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="LealTitleBar"/> class.
        /// </summary>
        public LealTitleBar()
        {
            // Enable double buffering to reduce flicker and improve rendering performance.
            DoubleBuffered = true;

            // Ensure the title bar is redrawn when resized.
            SetStyle(ControlStyles.ResizeRedraw, true);

            InitializeComponent();
            InitializeObjects();
        }

        /// <summary>
        /// Gets or sets a value indicating whether the title bar is using the black theme.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        public bool BlackTheme
        {
            get => _blackTheme;
            set
            {
                _blackTheme = value;
                UpdateIconsAndColors();
            }
        }

        /// <summary>
        /// Initializes title bar objects and event handlers.
        /// </summary>
        private void InitializeObjects()
        {
            // Customize the appearance and event handlers for window control buttons and title bar.
            buttonClose.FlatAppearance.MouseOverBackColor = Color.Red;

            // Event handlers for window control buttons
            buttonMin.Click += ButtonMin_Click;
            buttonMaxNor.Click += ButtonMaxNor_Click;
            buttonClose.Click += ButtonClose_Click;

            // Event handlers to enable dragging the form from the title bar
            panelTop.MouseDown += ControlMouseDown;
            labelIcon.MouseDown += ControlMouseDown;
            labelTitle.MouseDown += ControlMouseDown;

            UpdateIconsAndColors();
        }

        /// <summary>
        /// Updates the icons and colors of the title bar based on the current theme.
        /// </summary>
        private void UpdateIconsAndColors()
        {
            buttonClose.Image = _blackTheme ? ResourceMngr.close_black_theme : ResourceMngr.close_white_theme;
            buttonMaxNor.Image = _blackTheme ? ResourceMngr.normalize_black_theme : ResourceMngr.maximize_black_theme;
            buttonMin.Image = _blackTheme ? ResourceMngr.minimize_black_theme : ResourceMngr.minimize_white_theme;

            if (Parent == null)
                return;

            var maximized = ((Form)Parent).WindowState == FormWindowState.Maximized;

            buttonMaxNor.Image = _blackTheme
                    ? maximized
                                ? ResourceMngr.normalize_black_theme
                                : ResourceMngr.maximize_black_theme
                    : maximized
                                ? ResourceMngr.normalize_white_theme
                                : ResourceMngr.maximize_white_theme;

            if (Parent is Form parent)
            {
                labelTitle.Text = Parent.Text;
                labelTitle.ForeColor = parent.ForeColor;

                if (parent.Icon != null)
                    labelIcon.Image = parent.Icon.ToBitmap();
            }
        }

        /// <summary>
        /// Handles changes to the parent control of the title bar.
        /// </summary>
        private void LealTitleBar_ParentChanged(object sender, EventArgs e)
        {
            // Ensure the parent exists
            if (Parent == null)
                return;

            // Ensure the parent is a Form type
            if (Parent is not Form)
                throw new ApplicationException("Invalid Parent type for LealTitleBar. LealTitleBar require a Form as Parent");

            BackColor = Parent.BackColor;
            UpdateIconsAndColors();
        }

        /// <summary>
        /// Handles the resize event of the title bar.
        /// </summary>
        private void LealTitleBar_Resize(object? sender, EventArgs e) => UpdateIconsAndColors();

        /// <summary>
        /// Handles button minimize click
        /// </summary>
        private void ButtonMin_Click(object? sender, EventArgs e)
        {
            if (Parent is Form form)
                form.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Handles button maximize/normalize click
        /// </summary>
        private void ButtonMaxNor_Click(object? sender, EventArgs e)
        {
            if (Parent is Form form)
            {
                var maximized = form.WindowState == FormWindowState.Maximized;
                form.WindowState = maximized ? FormWindowState.Normal : FormWindowState.Maximized;
            }
        }

        /// <summary>
        /// Handles button close click
        /// </summary>
        private void ButtonClose_Click(object? sender, EventArgs e)
        {
            if (Parent is Form form)
                form.Close();
        }

        /// <summary>
        /// Handle parent dragging
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ControlMouseDown(object? sender, MouseEventArgs e)
        {
            if (Parent == null)
                return;

            Parent.Handle.ControlMouseDown(e);
        }
    }
}