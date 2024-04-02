using System.Runtime.InteropServices;

namespace LealForms.UI.Utils.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="Form"/>s, enhancing and simplifying their functionality.
    /// </summary>
    public static class FormExtensions
    {
        /// <summary>
        /// Checks if the system's theme is set to dark mode.
        /// </summary>
        /// <returns>True if the system is using dark mode; otherwise, false.</returns>
        [DllImport("UXTheme.dll", SetLastError = true, EntryPoint = "#138")]
        private static extern bool ShouldSystemUseDarkMode();

        /// <summary>
        /// Checks if the system's theme is set to dark mode. This method utilizes an internal Windows API function <see cref="ShouldSystemUseDarkMode"/>
        /// and should be used with caution as it may change or be removed in future versions of Windows.
        /// </summary>
        /// <returns>True if the system is using dark mode; otherwise, false. Returns false if there's an error calling the API.</returns>
        public static bool UseDarkMode()
        {
            try
            {
                return ShouldSystemUseDarkMode();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Enables or disables the immersive dark mode for a window.
        /// </summary>
        /// <param name="handle">The handle to the window for which to set the immersive dark mode.</param>
        /// <param name="enabled">A boolean value indicating whether to enable or disable dark mode.</param>
        /// <returns>True if the operation was successful, false otherwise.</returns>
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

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

        /// <summary>
        /// Enables or disables the immersive dark mode for a window. This method determines the appropriate dark mode attribute
        /// based on the Windows 10 version and applies it to the window specified by the handle. Immersive dark mode is only supported
        /// on Windows 10 version 1809 (October 2018 Update) and later. For versions 20H1 (May 2020 Update) and later, a different attribute is used.
        /// </summary>
        /// <param name="handle">The handle to the window for which to set the immersive dark mode.</param>
        /// <param name="enabled">Specifies whether to enable (true) or disable (false) dark mode for the window.</param>
        /// <returns>True if dark mode was successfully applied; otherwise, false. This can return false if the OS version does not support dark mode or if the window handle is invalid.</returns>
        public static bool UseImmersiveDarkMode(this IntPtr handle, bool enabled)
        {
            if (IsWindows10OrGreater(17763))
            {
                var attribute = IsWindows10OrGreater(18985)
                    ? Constants.DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1
                    : Constants.DWMWA_USE_IMMERSIVE_DARK_MODE;

                int useImmersiveDarkMode = enabled ? 1 : 0;
                return DwmSetWindowAttribute(handle, attribute, ref useImmersiveDarkMode, sizeof(int)) == 0;
            }

            return false;
        }


        /// <summary>
        /// Checks if the operating system is Windows 10 or greater, optionally checking if it's a specific build or newer.
        /// </summary>
        /// <param name="build">The minimum build number to check for. Default is -1, which checks for any Windows 10 version.</param>
        /// <returns>True if the OS is Windows 10 with a build number greater than or equal to the specified build.</returns>
        private static bool IsWindows10OrGreater(int build = -1)
        {
            return Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= build;
        }
    }
}