using System.Runtime.InteropServices;

namespace LealForms.UI.Utils.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="Control"/>s, enhancing and simplifying their functionality.
    /// </summary>
    public static class ControlExtensions
    {
        /// <summary>
        /// Import the ReleaseCapture function from user32.dll, allowing us to release the mouse capture from the window.
        /// </summary>
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        /// <summary>
        /// Import the SendMessage function from user32.dll, enabling us to send messages to windows (e.g., to simulate mouse clicks, movements).
        /// This function calls the window procedure for the specified window and does not return until the window procedure has processed the message.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST ((IntPtr)0xffff), the message is sent to all top-level windows in the system.</param>
        /// <param name="Msg">The message to be sent. For lists of the system-provided messages, see System-Defined Messages in the Windows documentation.</param>
        /// <param name="wParam">Additional message-specific information.</param>
        /// <param name="lParam">Additional message-specific information.</param>
        /// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        /// <summary>
        /// Import the CreateRoundRectRgn function from Gdi32.dll to create a region with rounded corners. This function is part of the Windows GDI, allowing for more complex shape definitions in UI elements.
        /// </summary>
        /// <param name="nLeftRect">x-coordinate of the upper-left corner of the rectangle</param>
        /// <param name="nTopRect">y-coordinate of the upper-left corner</param>
        /// <param name="nRightRect">x-coordinate of the lower-right corner</param>
        /// <param name="nBottomRect">y-coordinate of the lower-right corner</param>
        /// <param name="nWidthEllipse">width of the ellipse used to create the rounded corners</param>
        /// <param name="nHeightEllipse">height of the ellipse</param>
        /// <returns></returns>
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        /// <summary>
        /// This method allows a control to initiate window dragging behavior when the mouse is pressed down on it. It's particularly useful for custom UI elements that you wish to make draggable.
        /// </summary>
        /// <param name="handle">IntPtr handle of your Form.</param>
        /// <param name="mouseEvent">Mouse event arguments, providing details about the mouse press.</param>
        public static void ControlMouseDown(this IntPtr handle, MouseEventArgs mouseEvent)
        {
            // Only proceed if the left mouse button was pressed; ignore other mouse button presses.
            if (mouseEvent.Button != MouseButtons.Left) return;

            // Release the mouse capture from the current window, allowing custom drag behavior.
            ReleaseCapture();

            // Send a message to the window to simulate a mouse click and drag on the window's title bar (caption).
            // This makes the window follow the mouse, mimicking the drag behavior.
            _ = SendMessage(handle, Constants.WM_NCLBUTTONDOWN, Constants.HT_CAPTION, 0);
        }

        /// <summary>
        /// Generates a Region object with rounded corners for a given control. This method uses the CreateRoundRectRgn function
        /// from the Windows API to create a region that can then be applied to the control, effectively giving it rounded corners.
        /// </summary>
        /// <param name="control">The control to which the rounded region will be applied. This extension method allows
        /// any Control-derived object to directly invoke this method and have its region adjusted.</param>
        /// <param name="width">The width of the control's region. This value should ideally match the control's current width
        /// or the width you intend to set on the control.</param>
        /// <param name="height">The height of the control's region. This value should ideally match the control's current height
        /// or the height you intend to set on the control.</param>
        /// <param name="curve">The radius of the curve used to create the rounded corners. Larger values result in more pronounced
        /// rounded corners. This value affects both the width and the height of the ellipse used to round the corners. default value: 20</param>
        public static Region GenerateRoundRegion(this Control control, int width, int height, int curve = 20)
            => control.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, width, height, curve, curve));

        /// <summary>
        /// Centralizes a control both horizontally and vertically relative to a reference control.
        /// </summary>
        /// <param name="control">The control to be centralized.</param>
        /// <param name="controlReference">The control used as a reference for centralization.</param>
        public static void CentralizeRelativeTo(this Control control, Control controlReference)
        {
            control.CentralizeHorizontallyRelativeTo(controlReference);
            control.CentralizeVerticallyRelativeTo(controlReference);
        }

        /// <summary>
        /// Centralizes a control horizontally relative to a reference control.
        /// </summary>
        /// <param name="control">The control to be centralized horizontally.</param>
        /// <param name="controlReference">The control used as a reference for horizontal centralization.</param>
        public static void CentralizeHorizontallyRelativeTo(this Control control, Control controlReference)
        {
            // Calculate the center point of the reference control.
            var centerPoint = new Point(controlReference.Width / 2, controlReference.Height / 2);
            // Calculate the new X position for the control to be centralized.
            var xValue = controlReference.Location.X + centerPoint.X - (control.Width / 2);
            // Update the control's location to the new centralized X position, keeping the current Y position.
            control.Location = new Point(xValue, control.Location.Y);
        }

        /// <summary>
        /// Centralizes a control vertically relative to a reference control.
        /// </summary>
        /// <param name="control">The control to be centralized vertically.</param>
        /// <param name="controlReference">The control used as a reference for vertical centralization.</param>
        public static void CentralizeVerticallyRelativeTo(this Control control, Control controlReference)
        {
            // Calculate the center point of the reference control.
            var centerPoint = new Point(controlReference.Width / 2, controlReference.Height / 2);
            // Calculate the new Y position for the control to be centralized.
            var yValue = controlReference.Location.Y + centerPoint.Y - (control.Height / 2);
            // Update the control's location to the new centralized Y position, keeping the current X position.
            control.Location = new Point(control.Location.X, yValue);
        }

        /// <summary>
        /// Updates the Y position of a control to an absolute value.
        /// </summary>
        /// <param name="control">The control to update.</param>
        /// <param name="y">The new absolute Y position.</param>
        public static void SetY(this Control control, int y)
        {
            var pos = control.Location;
            control.Location = new Point(pos.X, y);
        }

        /// <summary>
        /// Updates the X position of a control to an absolute value.
        /// </summary>
        /// <param name="control">The control to update.</param>
        /// <param name="x">The new absolute X position.</param>
        public static void SetX(this Control control, int x)
        {
            var pos = control.Location;
            control.Location = new Point(x, pos.Y);
        }

        /// <summary>
        /// Updates the Y position of a control to be immediately below a reference control, with a specified offset.
        /// </summary>
        /// <param name="control">The control to update.</param>
        /// <param name="controlReference">The reference control.</param>
        /// <param name="offsetBetween">The vertical offset between the two controls.</param>
        public static void SetYOffsetBelow(this Control control, Control controlReference, int offsetBetween)
        {
            var newYPos = controlReference.Location.Y + controlReference.Height + offsetBetween;
            SetY(control, newYPos);
        }

        /// <summary>
        /// Updates the X position of a control to be immediately to the right of a reference control, with a specified offset.
        /// </summary>
        /// <param name="control">The control to update.</param>
        /// <param name="controlReference">The reference control.</param>
        /// <param name="offsetBetween">The horizontal offset between the two controls.</param>
        public static void SetXOffsetRight(this Control control, Control controlReference, int offsetBetween)
        {
            var newXPos = controlReference.Location.X + controlReference.Width + offsetBetween;
            SetX(control, newXPos);
        }

        /// <summary>
        /// Adds a child control to the parent control's Controls collection.
        /// This extension method provides a shorthand for adding child controls to a parent,
        /// simplifying the syntax and enhancing code readability.
        /// </summary>
        /// <param name="parent">The parent control to which the child control will be added. 
        /// This is the control that will contain the child control.</param>
        /// <param name="child">The child control to be added to the parent control's Controls collection.
        /// This is the control that will be displayed within the parent control.</param>
        public static void Add(this Control parent, Control child) => parent.Controls.Add(child);
    }
}