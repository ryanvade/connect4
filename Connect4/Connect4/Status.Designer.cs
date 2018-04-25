namespace Connect4
{
    partial class Status
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
            this.STATUS_LABEL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // STATUS_LABEL
            // 
            this.STATUS_LABEL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.STATUS_LABEL.AutoSize = true;
            this.STATUS_LABEL.Location = new System.Drawing.Point(275, 85);
            this.STATUS_LABEL.Name = "STATUS_LABEL";
            this.STATUS_LABEL.Size = new System.Drawing.Size(46, 17);
            this.STATUS_LABEL.TabIndex = 0;
            this.STATUS_LABEL.Text = "label1";
            // 
            // Status
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 186);
            this.Controls.Add(this.STATUS_LABEL);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Status";
            this.Text = "Status";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label STATUS_LABEL;
    }
}