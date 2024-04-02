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
                TopLeftGradientColor = Color.Blue,
                BottomLeftGradientColor = Color.Blue,
                TopRightGradientColor = Color.Black,
                BottomRightGradientColor = Color.Black,
            };

            this.Add(backgroundGradientPanel);

            base.InitializeObjects();
        }
    }
}
