﻿namespace LealForms.UI.Forms
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
            SuspendLayout();
            // 
            // LealBorderlessForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(903, 482);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "LealBorderlessForm";
            SizeGripStyle = SizeGripStyle.Show;
            Text = "LealBorderlessForm";
            Resize += LealBorderlessForm_Resize;
            ResumeLayout(false);
        }

        #endregion
    }
}