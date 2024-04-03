namespace LealForms.UI.Controls.Buttons
{
    public class LealSelectableButton : LealBaseButton
    {
        /// <summary>
        /// Delegate for click event handlers.
        /// </summary>
        public delegate void Clicked();

        /// <summary>
        /// Event fired when the button is clicked.
        /// </summary>
        public event Clicked? OnClicked;

        /// <summary>
        /// Initializes a new instance of the <see cref="LealSelectableButton"/> class,
        /// auto set MouseClick event to handle button selection.
        /// </summary>
        public LealSelectableButton()
        {
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
        /// Handles the MouseClick event. It sets all sibling LealSelectableButton instances
        /// within the same parent to their unselected state before marking the clicked button as selected.
        /// It then invokes the OnClicked event, notifying subscribers that this button was clicked.
        /// </summary>
        /// <param name="sender">The source of the event, typically the button itself.</param>
        /// <param name="e">Details about the mouse click event.</param>
        private void LealSelectableButton_MouseClick(object? sender, MouseEventArgs e)
        {
            if (Parent == null)
            {
                BackColor = SelectedColor;
                return;
            }

            // Set all sibling buttons' background color to their unselected color.
            foreach (var control in Parent.Controls)
            {
                if (control is LealSelectableButton lsb)
                    lsb.BackColor = lsb.UnselectedColor;
            }

            
            BackColor = SelectedColor; // Set this button's background color to the selected color.

            OnClicked?.Invoke(); // Invoke the OnClicked event to notify all subscribers.
        }
    }
}