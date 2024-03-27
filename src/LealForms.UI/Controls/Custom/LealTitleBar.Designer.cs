namespace LealForms.UI.Controls.Custom
{
    partial class LealTitleBar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonClose = new Button();
            buttonMaxNor = new Button();
            buttonMin = new Button();
            panelTop = new Panel();
            labelTitle = new Label();
            labelIcon = new Label();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // buttonClose
            // 
            buttonClose.Dock = DockStyle.Right;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.Image = Resources.ResourceMngr.close_white_theme;
            buttonClose.Location = new Point(531, 0);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(48, 32);
            buttonClose.TabIndex = 0;
            buttonClose.UseVisualStyleBackColor = true;
            // 
            // buttonMaxNor
            // 
            buttonMaxNor.Dock = DockStyle.Right;
            buttonMaxNor.FlatAppearance.BorderSize = 0;
            buttonMaxNor.FlatStyle = FlatStyle.Flat;
            buttonMaxNor.Image = Resources.ResourceMngr.maximize_white_theme;
            buttonMaxNor.Location = new Point(483, 0);
            buttonMaxNor.Name = "buttonMaxNor";
            buttonMaxNor.Size = new Size(48, 32);
            buttonMaxNor.TabIndex = 1;
            buttonMaxNor.UseVisualStyleBackColor = true;
            // 
            // buttonMin
            // 
            buttonMin.Dock = DockStyle.Right;
            buttonMin.FlatAppearance.BorderSize = 0;
            buttonMin.FlatStyle = FlatStyle.Flat;
            buttonMin.Image = Resources.ResourceMngr.minimize_white_theme;
            buttonMin.Location = new Point(435, 0);
            buttonMin.Name = "buttonMin";
            buttonMin.Size = new Size(48, 32);
            buttonMin.TabIndex = 2;
            buttonMin.UseVisualStyleBackColor = true;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(labelTitle);
            panelTop.Controls.Add(labelIcon);
            panelTop.Dock = DockStyle.Fill;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(435, 32);
            panelTop.TabIndex = 3;
            // 
            // labelTitle
            // 
            labelTitle.Dock = DockStyle.Fill;
            labelTitle.Location = new Point(48, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(387, 32);
            labelTitle.TabIndex = 1;
            labelTitle.Text = "Title";
            labelTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelIcon
            // 
            labelIcon.Dock = DockStyle.Left;
            labelIcon.Location = new Point(0, 0);
            labelIcon.Name = "labelIcon";
            labelIcon.Size = new Size(48, 32);
            labelIcon.TabIndex = 0;
            // 
            // LealTitleBar
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.Control;
            Controls.Add(panelTop);
            Controls.Add(buttonMin);
            Controls.Add(buttonMaxNor);
            Controls.Add(buttonClose);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MaximumSize = new Size(100000, 32);
            MinimumSize = new Size(144, 32);
            Name = "LealTitleBar";
            Size = new Size(579, 32);
            Resize += LealTitleBar_Resize;
            ParentChanged += LealTitleBar_ParentChanged;
            panelTop.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button buttonClose;
        private Button buttonMaxNor;
        private Button buttonMin;
        private Panel panelTop;
        private Label labelIcon;
        private Label labelTitle;
    }
}
