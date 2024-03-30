namespace LealForms.UI.Utils
{
    /// <summary>
    /// This class defines constants used in the Extensions classes for window messages and parameters.
    /// </summary>
    internal static class Constants
    {
        // Message indicating that the left mouse button was pressed in the non-client area of a window.
        internal static readonly int WM_NCLBUTTONDOWN = 0xA1;

        // Hit-test value indicating the title bar or caption area of a window.
        internal static readonly int HT_CAPTION = 0x2;

        // Message used to determine what part of a window corresponds to a specific point.
        internal static readonly int WM_NCHITTEST = 0x84;

        // Hit-test value for the bottom border of a window.
        internal static readonly int HTBOTTOM = 15;

        // Hit-test value for the right border of a window.
        internal static readonly int HTRIGHT = 11;

        // Hit-test value for the bottom-right corner of a window.
        internal static readonly int HTBOTTOMRIGHT = 17;
    }
}