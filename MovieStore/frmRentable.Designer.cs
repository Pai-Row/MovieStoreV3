namespace MovieStore
{
    partial class frmRentable
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
            this.lblReturnDate = new System.Windows.Forms.Label();
            this.txtReturn = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblReturnDate
            // 
            this.lblReturnDate.AutoSize = true;
            this.lblReturnDate.Location = new System.Drawing.Point(12, 213);
            this.lblReturnDate.Name = "lblReturnDate";
            this.lblReturnDate.Size = new System.Drawing.Size(98, 13);
            this.lblReturnDate.TabIndex = 4;
            this.lblReturnDate.Text = "Return Date (Days)";
            // 
            // txtReturn
            // 
            this.txtReturn.Location = new System.Drawing.Point(15, 229);
            this.txtReturn.Name = "txtReturn";
            this.txtReturn.Size = new System.Drawing.Size(100, 20);
            this.txtReturn.TabIndex = 1;
            this.txtReturn.Text = "5";
            // 
            // frmRentable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 266);
            this.Controls.Add(this.lblReturnDate);
            this.Controls.Add(this.txtReturn);
            this.Name = "frmRentable";
            this.Text = "Rentable";
            this.Controls.SetChildIndex(this.txtReturn, 0);
            this.Controls.SetChildIndex(this.lblReturnDate, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblReturnDate;
        private System.Windows.Forms.TextBox txtReturn;
    }
}