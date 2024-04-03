namespace LealForms.UI.Controls.Buttons
{
    /// <summary>
    /// Represents the base class for button controls in the application, providing a standard style and appearance.
    /// This abstract class serves as a foundation for more specialized button types.
    /// </summary>
    public abstract class LealBaseButton : Button
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LealBaseButton"/> class, setting default styling and properties.
        /// </summary>
        protected LealBaseButton()
        {
            Text = "LealButton";
            Cursor = Cursors.Hand;
            BackColor = Color.White;
            Size = new Size(200, 50);
            FlatStyle = FlatStyle.Flat;
            Font = new Font("Arial", 12, FontStyle.Regular);
        }
    }
}