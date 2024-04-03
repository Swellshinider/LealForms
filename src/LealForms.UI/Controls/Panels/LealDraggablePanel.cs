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
        }

        /// <summary>
        /// Handles the MouseDown event to initiate dragging of the panel.
        /// </summary>
        private void LealDraggablePanel_MouseDown(object? sender, MouseEventArgs e)
            => this.FindParentForm()?.Handle.ControlMouseDown(e);
    }
}