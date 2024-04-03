using LealForms.UI.Utils.Extensions;

namespace LealForms.UI.Controls.Panels
{
    public class LealDraggablePanel : Panel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LealDraggablePanel"/> class,
        /// setting up event handlers for dragging functionality.
        /// </summary>
        public LealDraggablePanel()
        {
            MouseDown += LealDraggablePanel_MouseDown;
            ParentChanged += LealDraggablePanel_ParentChanged;
        }

        /// <summary>
        /// Updates the panel's background color to match its parent's background color.
        /// </summary>
        private void LealDraggablePanel_ParentChanged(object? sender, EventArgs e)
        {
            if (Parent != null)
                BackColor = Parent.BackColor;
        }

        /// <summary>
        /// Handles the MouseDown event to initiate dragging of the panel.
        /// </summary>
        private void LealDraggablePanel_MouseDown(object? sender, MouseEventArgs e)
        {
            if (Parent == null)
                Handle.ControlMouseDown(e);
            else
                Parent.Handle.ControlMouseDown(e);

        }
    }
}