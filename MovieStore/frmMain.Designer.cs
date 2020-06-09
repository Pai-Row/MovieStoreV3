namespace MovieStore
{
    partial class frmMain
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
            this.lblGenre = new System.Windows.Forms.Label();
            this.lstGenres = new System.Windows.Forms.ListBox();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnGenre = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(12, 9);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(36, 13);
            this.lblGenre.TabIndex = 0;
            this.lblGenre.Text = "Genre";
            // 
            // lstGenres
            // 
            this.lstGenres.FormattingEnabled = true;
            this.lstGenres.Location = new System.Drawing.Point(15, 25);
            this.lstGenres.Name = "lstGenres";
            this.lstGenres.Size = new System.Drawing.Size(151, 121);
            this.lstGenres.TabIndex = 1;
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(182, 145);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 36);
            this.btnQuit.TabIndex = 2;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnGenre
            // 
            this.btnGenre.Location = new System.Drawing.Point(182, 25);
            this.btnGenre.Name = "btnGenre";
            this.btnGenre.Size = new System.Drawing.Size(75, 36);
            this.btnGenre.TabIndex = 3;
            this.btnGenre.Text = "Open Genre";
            this.btnGenre.UseVisualStyleBackColor = true;
            // 
            // btnOrders
            // 
            this.btnOrders.Location = new System.Drawing.Point(182, 67);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(75, 36);
            this.btnOrders.TabIndex = 4;
            this.btnOrders.Text = "Current Orders";
            this.btnOrders.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 194);
            this.Controls.Add(this.btnOrders);
            this.Controls.Add(this.btnGenre);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.lstGenres);
            this.Controls.Add(this.lblGenre);
            this.Name = "frmMain";
            this.Text = "Movie Store";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.ListBox lstGenres;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnGenre;
        private System.Windows.Forms.Button btnOrders;
    }
}

