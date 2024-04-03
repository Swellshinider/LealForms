namespace LealForms.UI.Controls.Buttons
{
    public class LealSelectableButton : LealBaseButton
    {
        private readonly IEnumerable<LealSelectableButton> _buttonsList;

        /// <summary>
        /// Initializes a new instance of the class with a list of controls.
        /// This constructor filters the provided controls to include only those that are instances of LealSelectableButton
        /// and forwards them to the main constructor.
        /// </summary>
        /// <param name="controls">The list of controls to filter and use as selectable buttons.</param>
        public LealSelectableButton(List<Control> controls) 
            : this(controls.OfType<LealSelectableButton>()) { }

        /// <summary>
        /// Main constructor that initializes a new instance of the class with a collection of LealSelectableButton instances.
        /// This setup allows for managing a group of selectable buttons together.
        /// </summary>
        /// <param name="buttonsList">The collection of LealSelectableButton instances to be managed.</param>
        public LealSelectableButton(IEnumerable<LealSelectableButton> buttonsList)
        {
            _buttonsList = buttonsList;
            MouseClick += LealSelectableButton_MouseClick;
        }

        /// <summary>
        /// Gets or sets the color of the button when it is selected.
        /// </summary>
        public Color SelectedColor { get; set; } = Color.Blue;

        /// <summary>
        /// Gets or sets the color of the button when it is not selected.
        /// </summary>
        public Color UnselectedColor { get; set; } = Color.White;

        /// <summary>
        /// Handles the MouseClick event. When a button is clicked, it sets the background color of all buttons
        /// in the group to their unselected color, then sets its own background color to the selected color.
        /// </summary>
        private void LealSelectableButton_MouseClick(object? sender, MouseEventArgs e)
        {
            foreach (var buttons in _buttonsList)
                buttons.BackColor = buttons.UnselectedColor;

            BackColor = SelectedColor;
        }
    }
}