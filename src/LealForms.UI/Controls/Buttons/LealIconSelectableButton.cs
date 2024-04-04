using LealForms.UI.Controls.Enums;
using LealForms.UI.Utils.Extensions;
using System.Diagnostics.CodeAnalysis;

namespace LealForms.UI.Controls.Buttons
{
    /// <summary>
    /// Represents a button with selectable states and an icon, extending the LealSelectableButton.
    /// Allows for customization of the icon's position and appearance alongside text.
    /// </summary>
    public class LealIconSelectableButton : LealSelectableButton
    {
        private string? _text;
        private Image? _iconImage;
        private ImagePosition _imagePosition;

        private readonly int _iconWidth;
        private readonly bool _showIconBorder;

        private Label? _iconLabel;
        private Label? _labelText;

        /// <summary>
        /// Default constructor initializing the button with no icon, placing the icon to the left, and not showing an icon border.
        /// </summary>
        public LealIconSelectableButton()
            : this(null, ImagePosition.Left, false) { }

        /// <summary>
        /// Constructor allowing for detailed configuration of the icon's appearance and position.
        /// </summary>
        /// <param name="iconImage">The image to be used as the icon.</param>
        /// <param name="imagePosition">The position of the icon relative to the text.</param>
        /// <param name="showIconBorder">Indicates whether a border should be shown around the icon.</param>
        /// <param name="iconWidth">The width of the icon area.</param>
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

        /// <summary>
        /// Gets or sets the icon image displayed on the button.
        /// </summary>
        public Image? IconImage
        {
            get => _iconImage;
            set
            {
                _iconImage = value;
                UpdateImage();
            }
        }

        /// <summary>
        /// Gets or sets the position of the icon relative to the text on the button.
        /// </summary>
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
                _text = value; UpdateText();
            }
        }

        public override ContentAlignment TextAlign
        {
            get => base.TextAlign; 
            set
            {
                base.TextAlign = value; UpdateText();
            }
        }

        public override Color BackColor
        {
            get => base.BackColor; 
            set
            {
                base.BackColor = value; UpdateImage(); UpdateText();
            }
        }

        public override Color ForeColor
        {
            get => base.ForeColor; 
            set
            {
                base.ForeColor = value; UpdateText();
            }
        }

        /// <summary>
        /// Initializes the button objects, configuring labels for icon and text display.
        /// </summary>
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

            // Forward mouse events from the labels to the button's event handlers.
            AttachLabelEvents(_iconLabel);
            AttachLabelEvents(_labelText);

            this.Add(_labelText);
            this.Add(_iconLabel);
        }

        /// <summary>
        /// Attaches event handlers to a label to forward mouse events to the button.
        /// </summary>
        /// <param name="label">The label to attach event handlers to.</param>
        private void AttachLabelEvents(Label label)
        {
            label.MouseEnter += (sender, e) => OnMouseEnter(e);
            label.MouseLeave += (sender, e) => OnMouseLeave(e);
            label.MouseDown += (sender, e) => OnMouseDown(e);
            label.MouseClick += (sender, e) => OnMouseClick(e);
        }

        /// <summary>
        /// Updates the icon's appearance and position based on the current properties.
        /// </summary>
        private void UpdateImage()
        {
            if (_iconLabel == null)
                return;

            if (IconImage != null)
                _iconLabel!.Image = IconImage;
            _iconLabel!.Dock = ImagePosition == ImagePosition.Left ? DockStyle.Left : DockStyle.Right;
        }

        /// <summary>
        /// Updates the text label's content and appearance based on the current properties.
        /// </summary>
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