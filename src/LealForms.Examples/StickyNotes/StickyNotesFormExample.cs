using LealForms.UI.Controls.Buttons;
using LealForms.UI.Controls.Enums;
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
            var iconButton = new LealIconSelectableButton(null, ImagePosition.Left, true)
            {
                Text = "Test1"
            };
            var iconButton2 = new LealIconSelectableButton(null, ImagePosition.Left, false)
            {
                Text = "Test2",
                TextAlign = ContentAlignment.MiddleLeft,
            };
            var iconButton3 = new LealIconSelectableButton(null, ImagePosition.Left, true)
            {
                Text = "Test3",
                TextAlign = ContentAlignment.MiddleRight
            };

            backgroundGradientPanel.Add(iconButton);
            backgroundGradientPanel.Add(iconButton2);
            backgroundGradientPanel.Add(iconButton3);
            backgroundGradientPanel.Controls.WaterFallControlsOfType<LealIconSelectableButton>(15);

            this.Add(backgroundGradientPanel);
            base.InitializeObjects();
        }
    }
}