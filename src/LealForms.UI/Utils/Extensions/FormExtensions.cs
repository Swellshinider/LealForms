namespace LealForms.UI.Utils.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="Form"/>s, enhancing and simplifying their functionality.
    /// </summary>
    public static class FormExtensions
    {
        /// <summary>
        /// Transitions the user interface from one form to another by hiding the current form and showing the target form.
        /// Additionally, it ensures the current form is closed when the target form is closed.
        /// </summary>
        /// <param name="currentForm">The form from which to transition.</param>
        /// <param name="targetForm">The form to transition to.</param>
        public static void TransitionToForm(this Form currentForm, Form targetForm)
        {
            currentForm.ToggleVisibility(false);
            targetForm.Closed += (s, e) => currentForm.Close();
            targetForm.ToggleVisibility(true);
        }

        /// <summary>
        /// Sets the visibility, enabled state, and taskbar visibility of the form. If showing the form,
        /// it will be made visible, enabled, and shown in the taskbar; otherwise, it will be hidden.
        /// </summary>
        /// <param name="form">The form to modify.</param>
        /// <param name="show">Whether to show or hide the form. True to show the form; false to hide it.</param>
        public static void ToggleVisibility(this Form form, bool show = true)
        {
            form.Visible = show;
            form.Enabled = show;
            form.ShowInTaskbar = show;

            if (show)
                form.Show();
            else
                form.Hide();
        }
    }
}