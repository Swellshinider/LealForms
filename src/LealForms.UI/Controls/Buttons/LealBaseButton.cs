namespace LealForms.UI.Controls.Buttons
{
    public abstract class LealBaseButton : Button
    {
        protected LealBaseButton()
        {
            Font = new Font("Arial", 12, FontStyle.Regular);
            FlatStyle = FlatStyle.Flat;
            BackColor = Color.White;
        }
    }
}