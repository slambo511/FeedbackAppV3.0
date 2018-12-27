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
            this.btnTestDB = new System.Windows.Forms.Button();
            this.cboIntances = new System.Windows.Forms.ComboBox();
            this.cboTables = new System.Windows.Forms.ComboBox();
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
            // btnTestDB
            // 
            this.btnTestDB.Location = new System.Drawing.Point(12, 55);
            this.btnTestDB.Name = "btnTestDB";
            this.btnTestDB.Size = new System.Drawing.Size(183, 23);
            this.btnTestDB.TabIndex = 1;
            this.btnTestDB.Text = "Test DB";
            this.btnTestDB.UseVisualStyleBackColor = true;
            this.btnTestDB.Click += new System.EventHandler(this.btnTestDB_Click);
            // 
            // cboIntances
            // 
            this.cboIntances.FormattingEnabled = true;
            this.cboIntances.Location = new System.Drawing.Point(215, 14);
            this.cboIntances.Name = "cboIntances";
            this.cboIntances.Size = new System.Drawing.Size(177, 21);
            this.cboIntances.TabIndex = 2;
            // 
            // cboTables
            // 
            this.cboTables.FormattingEnabled = true;
            this.cboTables.Location = new System.Drawing.Point(215, 57);
            this.cboTables.Name = "cboTables";
            this.cboTables.Size = new System.Drawing.Size(177, 21);
            this.cboTables.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cboTables);
            this.Controls.Add(this.cboIntances);
            this.Controls.Add(this.btnTestDB);
            this.Controls.Add(this.btnTestEncryption);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTestEncryption;
        private System.Windows.Forms.Button btnTestDB;
        private System.Windows.Forms.ComboBox cboIntances;
        private System.Windows.Forms.ComboBox cboTables;
    }
}

