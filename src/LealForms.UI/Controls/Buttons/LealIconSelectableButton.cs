using LealForms.UI.Controls.Enums;
using LealForms.UI.Utils.Extensions;
using System.Diagnostics.CodeAnalysis;

namespace LealForms.UI.Controls.Buttons
{
    public class LealIconSelectableButton : LealSelectableButton
    {
        private string? _text;
        private Image? _iconImage;
        private ImagePosition _imagePosition;

        private readonly int _iconWidth;
        private readonly bool _showIconBorder;

        private Label? _iconLabel;
        private Label? _labelText;

        public LealIconSelectableButton()
            : this(null, ImagePosition.Left, false) { }

        public LealIconSelectableButton(Image? iconImage, ImagePosition imagePosition, bool showIconBorder, int iconWidth = 50)
        {
            _text = "";
            base.Text = "";
            _iconWidth = iconWidth;
            _showIconBorder = showIconBorder;
            IconImage = iconImage;
            ImagePosition = imagePosition;
            InitializeObjects();
        }

        public Image? IconImage
        {
            get => _iconImage;
            set
            {
                _iconImage = value;
                UpdateImage();
            }
        }

        public ImagePosition ImagePosition
        {
            get => _imagePosition;
            set
            {
                _imagePosition = value;
                UpdateImage();
            }
        }

        [AllowNull]
        public override string Text
        {
            get => _text ?? "";
            set
            {
                _text = value;
                UpdateText();
            }
        }

        public override ContentAlignment TextAlign
        {
            get => base.TextAlign;
            set
            {
                base.TextAlign = value;
                UpdateText();
            }
        }

        private void InitializeObjects()
        {
            _iconLabel = new Label()
            {
                AutoSize = false,
                Width = _iconWidth,
                FlatStyle = FlatStyle.Flat,
                ImageAlign = ContentAlignment.MiddleCenter,
                BorderStyle = _showIconBorder ? BorderStyle.FixedSingle : BorderStyle.None,
                Dock = ImagePosition == ImagePosition.Left ? DockStyle.Left : DockStyle.Right,
            };
            if (IconImage != null)
                _iconLabel.Image = IconImage;

            _labelText = new Label()
            {
                Text = Text,
                Font = base.Font,
                AutoSize = false,
                ForeColor = ForeColor,
                Dock = DockStyle.Fill,
                TextAlign = TextAlign,
            };

            _iconLabel.MouseEnter += (sender, e) => OnMouseEnter(e);
            _iconLabel.MouseLeave += (sender, e) => OnMouseLeave(e);
            _iconLabel.MouseDown += (sender, e) => OnMouseDown(e);
            _iconLabel.MouseClick += (sender, e) => OnMouseClick(e);

            _labelText.MouseEnter += (sender, e) => OnMouseEnter(e);
            _labelText.MouseLeave += (sender, e) => OnMouseLeave(e);
            _labelText.MouseDown += (sender, e) => OnMouseDown(e);
            _labelText.MouseClick += (sender, e) => OnMouseClick(e);

            this.Add(_labelText);
            this.Add(_iconLabel);
        }

        private void UpdateImage()
        {
            if (_iconLabel == null)
                return;

            if (IconImage != null)
                _iconLabel!.Image = IconImage;
            _iconLabel!.Dock = ImagePosition == ImagePosition.Left ? DockStyle.Left : DockStyle.Right;
        }

        private void UpdateText()
        {
            if (_labelText == null)
                return;

            _labelText!.Text = Text;
            _labelText!.ForeColor = ForeColor;
            _labelText!.TextAlign = TextAlign;
        }
    }
}