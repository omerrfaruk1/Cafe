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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sbtn
            // 
            this.sbtn.Location = new System.Drawing.Point(264, 7);
            this.sbtn.Name = "sbtn";
            this.sbtn.Size = new System.Drawing.Size(237, 87);
            this.sbtn.TabIndex = 0;
            this.sbtn.Text = "Salon";
            this.sbtn.UseVisualStyleBackColor = true;
            this.sbtn.Click += new System.EventHandler(this.sbtn_Click);
            // 
            // bbtn
            // 
            this.bbtn.Location = new System.Drawing.Point(507, 6);
            this.bbtn.Name = "bbtn";
            this.bbtn.Size = new System.Drawing.Size(237, 87);
            this.bbtn.TabIndex = 0;
            this.bbtn.Text = "Balkon";
            this.bbtn.UseVisualStyleBackColor = true;
            this.bbtn.Click += new System.EventHandler(this.bbtn_Click);
            // 
            // babtn
            // 
            this.babtn.Location = new System.Drawing.Point(750, 6);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1079, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(237, 87);
            this.button1.TabIndex = 0;
            this.button1.Text = "Dolu Masalar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Formtables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 622);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.babtn);
            this.Controls.Add(this.bbtn);
            this.Controls.Add(this.sbtn);
            this.Name = "Formtables";
            this.Text = "tables";
            this.Load += new System.EventHandler(this.Formtables_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sbtn;
        private System.Windows.Forms.Button bbtn;
        private System.Windows.Forms.Button babtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}