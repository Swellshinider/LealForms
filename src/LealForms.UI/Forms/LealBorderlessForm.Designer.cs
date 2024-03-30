namespace LealForms.UI.Forms
{
    partial class LealBorderlessForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lealTitleBar1 = new Controls.Custom.LealTitleBar();
            SuspendLayout();
            // 
            // lealTitleBar1
            // 
            lealTitleBar1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            lealTitleBar1.BackColor = Color.White;
            lealTitleBar1.BlackTheme = false;
            lealTitleBar1.Dock = DockStyle.Top;
            lealTitleBar1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lealTitleBar1.Location = new Point(0, 0);
            lealTitleBar1.MaximumSize = new Size(100000, 32);
            lealTitleBar1.MinimumSize = new Size(144, 32);
            lealTitleBar1.Name = "lealTitleBar1";
            lealTitleBar1.Size = new Size(903, 32);
            lealTitleBar1.TabIndex = 0;
            // 
            // LealBorderlessForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(903, 482);
            Controls.Add(lealTitleBar1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "LealBorderlessForm";
            SizeGripStyle = SizeGripStyle.Show;
            Text = "LealBorderlessForm";
            Resize += LealBorderlessForm_Resize;
            ResumeLayout(false);
        }

        #endregion

        private Controls.Custom.LealTitleBar lealTitleBar1;
    }
}