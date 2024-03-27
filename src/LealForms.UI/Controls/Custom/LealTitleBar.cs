using LealForms.UI.Resources;
using LealForms.UI.Utils.Extensions;
using System.ComponentModel;

namespace LealForms.UI.Controls.Custom
{
    public partial class LealTitleBar : UserControl
    {
        private bool _blackTheme = false;

        public LealTitleBar()
        {
            // Enable double buffering to reduce flicker and improve rendering performance.
            DoubleBuffered = true;

            // Ensure the form is redrawn when resized.
            SetStyle(ControlStyles.ResizeRedraw, true);

            InitializeComponent();
            InitializeObjects();
        }

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

        private void InitializeObjects()
        {
            buttonClose.FlatAppearance.MouseOverBackColor = Color.Red;

            buttonMin.Click += ButtonMin_Click;
            buttonMaxNor.Click += ButtonMaxNor_Click;
            buttonClose.Click += ButtonClose_Click;
            panelTop.MouseDown += ControlMouseDown;
            labelIcon.MouseDown += ControlMouseDown;
            labelTitle.MouseDown += ControlMouseDown;
            UpdateIconsAndColors();
        }

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

                if (parent.Icon != null)
                    labelIcon.Image = parent.Icon.ToBitmap();
            }
        }

        private void LealTitleBar_ParentChanged(object sender, EventArgs e)
        {
            if (Parent == null)
                return;

            if (Parent is not Form)
                throw new ApplicationException("Invalid Parent type for LealTitleBar. LealTitleBar require a Form as Parent");

            BackColor = Parent.BackColor;
            UpdateIconsAndColors();
        }

        private void LealTitleBar_Resize(object? sender, EventArgs e) => UpdateIconsAndColors();

        private void ButtonMin_Click(object? sender, EventArgs e)
        {
            if (Parent is Form form)
                form.WindowState = FormWindowState.Minimized;
        }

        private void ButtonMaxNor_Click(object? sender, EventArgs e)
        {
            if (Parent is Form form)
            {
                var maximized = form.WindowState == FormWindowState.Maximized;
                form.WindowState = maximized ? FormWindowState.Normal : FormWindowState.Maximized;
            }   
        }

        private void ButtonClose_Click(object? sender, EventArgs e)
        {
            if (Parent is Form form)
                form.Close();
        }

        private void ControlMouseDown(object? sender, MouseEventArgs e)
        {
            if (Parent == null)
                return;

            Parent.Handle.ControlMouseDown(e);
        }
    }
}