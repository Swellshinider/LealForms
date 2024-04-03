using LealForms.UI.Controls.Buttons;
using LealForms.UI.Controls.Panels;
using LealForms.UI.Forms;
using LealForms.UI.Utils.Extensions;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LealForms.Examples.StickyNotes
{
    internal sealed class StickyNotesFormExample : LealBaseForm
    {
        internal StickyNotesFormExample()
        {

        }

        public override void InitializeObjects()
        {
            var backgroundGradientPanel = new LealGradientPanel
            {
                Dock = DockStyle.Fill,
                TopLeftGradientColor = Color.Black,
                BottomLeftGradientColor = Color.Black,
                TopRightGradientColor = Color.White,
                BottomRightGradientColor = Color.White,
            };
            var lealSelectableButton1 = new LealSelectableButton();
            var lealSelectableButton2 = new LealSelectableButton();
            var lealSelectableButton3 = new LealSelectableButton();
            var lealSelectableButton4 = new LealSelectableButton();
            var lealSelectableButton5 = new LealSelectableButton();

            this.Add(backgroundGradientPanel);
            backgroundGradientPanel.Add(lealSelectableButton1);
            backgroundGradientPanel.Add(lealSelectableButton2);
            backgroundGradientPanel.Add(lealSelectableButton3);
            backgroundGradientPanel.Add(lealSelectableButton4);
            backgroundGradientPanel.Add(lealSelectableButton5);

            backgroundGradientPanel.Controls.WaterFallControlsOfType<LealSelectableButton>(15);

            base.InitializeObjects();
        }
    }
}
