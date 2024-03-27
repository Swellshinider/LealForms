namespace LealForms.UI.Utils
{
    /// <summary>
    /// This class defines constants used in the Extensions classes for window messages and parameters.
    /// </summary>
    internal static class Constants
    {
        /// <summary>
        /// Window message indicating the left mouse button is pressed down on the non-client area (e.g., title bar).
        /// </summary>
        internal static readonly int WM_NCLBUTTONDOWN = 0xA1;

        /// <summary>
        /// Parameter indicating the mouse click occurred on the title bar (caption) area of the window.
        /// </summary>
        internal static readonly int HT_CAPTION = 0x2;
    }
}