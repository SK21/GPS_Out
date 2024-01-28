namespace GPS_Out
{
    partial class frmVTG
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVTG));
            this.lbKMH = new System.Windows.Forms.Label();
            this.lbKnots = new System.Windows.Forms.Label();
            this.lbMagHeading = new System.Windows.Forms.Label();
            this.lbHeading = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbKMH
            // 
            this.lbKMH.AutoSize = true;
            this.lbKMH.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKMH.Location = new System.Drawing.Point(142, 114);
            this.lbKMH.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbKMH.Name = "lbKMH";
            this.lbKMH.Size = new System.Drawing.Size(126, 24);
            this.lbKMH.TabIndex = 63;
            this.lbKMH.Text = "1234567890.";
            // 
            // lbKnots
            // 
            this.lbKnots.AutoSize = true;
            this.lbKnots.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKnots.Location = new System.Drawing.Point(142, 79);
            this.lbKnots.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbKnots.Name = "lbKnots";
            this.lbKnots.Size = new System.Drawing.Size(126, 24);
            this.lbKnots.TabIndex = 62;
            this.lbKnots.Text = "1234567890.";
            // 
            // lbMagHeading
            // 
            this.lbMagHeading.AutoSize = true;
            this.lbMagHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMagHeading.Location = new System.Drawing.Point(142, 44);
            this.lbMagHeading.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbMagHeading.Name = "lbMagHeading";
            this.lbMagHeading.Size = new System.Drawing.Size(126, 24);
            this.lbMagHeading.TabIndex = 61;
            this.lbMagHeading.Text = "1234567890.";
            // 
            // lbHeading
            // 
            this.lbHeading.AutoSize = true;
            this.lbHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeading.Location = new System.Drawing.Point(142, 9);
            this.lbHeading.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbHeading.Name = "lbHeading";
            this.lbHeading.Size = new System.Drawing.Size(126, 24);
            this.lbHeading.TabIndex = 60;
            this.lbHeading.Text = "1234567890.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 114);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 24);
            this.label5.TabIndex = 56;
            this.label5.Text = "KMH";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 79);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 24);
            this.label4.TabIndex = 55;
            this.label4.Text = "Knots";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 24);
            this.label2.TabIndex = 54;
            this.label2.Text = "Mag Heading";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 53;
            this.label1.Text = "Heading";
            // 
            // frmVTG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 158);
            this.Controls.Add(this.lbKMH);
            this.Controls.Add(this.lbKnots);
            this.Controls.Add(this.lbMagHeading);
            this.Controls.Add(this.lbHeading);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "frmVTG";
            this.ShowInTaskbar = false;
            this.Text = "VTG";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmVTG_FormClosed);
            this.Load += new System.EventHandler(this.frmVTG_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbKMH;
        private System.Windows.Forms.Label lbKnots;
        private System.Windows.Forms.Label lbMagHeading;
        private System.Windows.Forms.Label lbHeading;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}