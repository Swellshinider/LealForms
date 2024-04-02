namespace LealForms.UI.Utils
{
    /// <summary>
    /// This class defines constants used in the Extensions classes for window messages and parameters.
    /// </summary>
    internal static class Constants
    {
        #region Window Messages
        /// <summary>
        /// Message indicating that the left mouse button was pressed in the non-client area of a window.
        /// </summary>
        internal static readonly int WM_NCLBUTTONDOWN = 0xA1;

        /// <summary>
        /// Message used to determine what part of a window corresponds to a specific point, used for hit testing.
        /// </summary>
        internal static readonly int WM_NCHITTEST = 0x84;

        /// <summary>
        /// Constant representing the DWM window attribute for dark mode before Windows 10 version 20H1.
        /// </summary>
        internal const int DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19;

        /// <summary>
        /// Constant representing the DWM window attribute for dark mode after Windows 10 version 20H1.
        /// </summary>
        internal const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
        #endregion

        #region Hit Test Values
        /// <summary>
        /// Hit-test value indicating the title bar or caption area of a window.
        /// </summary>
        internal static readonly int HT_CAPTION = 0x2;

        /// <summary>
        /// Hit-test value for the bottom border of a window.
        /// </summary>
        internal static readonly int HTBOTTOM = 15;

        /// <summary>
        /// Hit-test value for the right border of a window.
        /// </summary>
        internal static readonly int HTRIGHT = 11;

        /// <summary>
        /// Hit-test value for the bottom-right corner of a window.
        /// </summary>
        internal static readonly int HTBOTTOMRIGHT = 17;

        /// <summary>
        /// Hit-test value for the top border of a window.
        /// </summary>
        internal static readonly int HTTOP = 12;

        /// <summary>
        /// Hit-test value for the top-right corner of a window.
        /// </summary>
        internal static readonly int HTTOPRIGHT = 14;

        /// <summary>
        /// Hit-test value for the top-left corner of a window.
        /// </summary>
        internal static readonly int HTTOPLEFT = 13;

        /// <summary>
        /// Hit-test value for the left border of a window.
        /// </summary>
        internal static readonly int HTLEFT = 10;

        /// <summary>
        /// Hit-test value for the bottom-left corner of a window.
        /// </summary>
        internal static readonly int HTBOTTOMLEFT = 16;
        #endregion
    }
}