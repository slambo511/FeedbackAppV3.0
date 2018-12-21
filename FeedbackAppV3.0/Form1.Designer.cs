namespace FeedbackAppV3._0
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
            this.btnTestEncryption = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTestEncryption
            // 
            this.btnTestEncryption.Location = new System.Drawing.Point(12, 12);
            this.btnTestEncryption.Name = "btnTestEncryption";
            this.btnTestEncryption.Size = new System.Drawing.Size(183, 23);
            this.btnTestEncryption.TabIndex = 0;
            this.btnTestEncryption.Text = "Test Encryption";
            this.btnTestEncryption.UseVisualStyleBackColor = true;
            this.btnTestEncryption.Click += new System.EventHandler(this.btnTestEncryption_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTestEncryption);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTestEncryption;
    }
}

