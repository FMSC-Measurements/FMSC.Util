namespace FMSC.Utility
{
    partial class FormDeviceInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.textBoxDeviceInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxDeviceInfo
            // 
            this.textBoxDeviceInfo.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.textBoxDeviceInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDeviceInfo.Location = new System.Drawing.Point(8, 8);
            this.textBoxDeviceInfo.Multiline = true;
            this.textBoxDeviceInfo.Name = "textBoxDeviceInfo";
            this.textBoxDeviceInfo.ReadOnly = true;
            this.textBoxDeviceInfo.Size = new System.Drawing.Size(223, 245);
            this.textBoxDeviceInfo.TabIndex = 0;
            // 
            // FormDeviceInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.textBoxDeviceInfo);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "FormDeviceInfo";
            this.Text = "Device Information";
            this.Load += new System.EventHandler(this.FormDeviceInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDeviceInfo;


    }
}