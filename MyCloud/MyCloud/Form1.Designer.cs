﻿namespace MyCloud
{
    partial class Form1
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
            this.brw = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // brw
            // 
            this.brw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.brw.Location = new System.Drawing.Point(0, 0);
            this.brw.MinimumSize = new System.Drawing.Size(20, 20);
            this.brw.Name = "brw";
            this.brw.Size = new System.Drawing.Size(852, 445);
            this.brw.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 445);
            this.Controls.Add(this.brw);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser brw;
    }
}