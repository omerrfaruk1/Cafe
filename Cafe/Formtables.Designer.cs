namespace Cafe
{
    partial class Formtables
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
            this.sbtn = new System.Windows.Forms.Button();
            this.bbtn = new System.Windows.Forms.Button();
            this.babtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // sbtn
            // 
            this.sbtn.Location = new System.Drawing.Point(12, 12);
            this.sbtn.Name = "sbtn";
            this.sbtn.Size = new System.Drawing.Size(237, 87);
            this.sbtn.TabIndex = 0;
            this.sbtn.Text = "Salon";
            this.sbtn.UseVisualStyleBackColor = true;
            this.sbtn.Click += new System.EventHandler(this.sbtn_Click);
            // 
            // bbtn
            // 
            this.bbtn.Location = new System.Drawing.Point(255, 11);
            this.bbtn.Name = "bbtn";
            this.bbtn.Size = new System.Drawing.Size(237, 87);
            this.bbtn.TabIndex = 0;
            this.bbtn.Text = "Balkon";
            this.bbtn.UseVisualStyleBackColor = true;
            this.bbtn.Click += new System.EventHandler(this.bbtn_Click);
            // 
            // babtn
            // 
            this.babtn.Location = new System.Drawing.Point(498, 11);
            this.babtn.Name = "babtn";
            this.babtn.Size = new System.Drawing.Size(237, 87);
            this.babtn.TabIndex = 0;
            this.babtn.Text = "Bahçe";
            this.babtn.UseVisualStyleBackColor = true;
            this.babtn.Click += new System.EventHandler(this.babtn_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 106);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1230, 511);
            this.panel1.TabIndex = 1;
            // 
            // tables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 622);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.babtn);
            this.Controls.Add(this.bbtn);
            this.Controls.Add(this.sbtn);
            this.Name = "tables";
            this.Text = "tables";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button sbtn;
        private System.Windows.Forms.Button bbtn;
        private System.Windows.Forms.Button babtn;
        private System.Windows.Forms.Panel panel1;
    }
}