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
            this.lblGenre.Location = new System.Drawing.Point(16, 11);
            this.lblGenre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(48, 17);
            this.lblGenre.TabIndex = 0;
            this.lblGenre.Text = "Genre";
            // 
            // lstGenres
            // 
            this.lstGenres.FormattingEnabled = true;
            this.lstGenres.ItemHeight = 16;
            this.lstGenres.Location = new System.Drawing.Point(20, 31);
            this.lstGenres.Margin = new System.Windows.Forms.Padding(4);
            this.lstGenres.Name = "lstGenres";
            this.lstGenres.Size = new System.Drawing.Size(200, 148);
            this.lstGenres.TabIndex = 1;
            this.lstGenres.DoubleClick += new System.EventHandler(this.lstGenres_DoubleClick);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(243, 178);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(100, 44);
            this.btnQuit.TabIndex = 2;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnGenre
            // 
            this.btnGenre.Location = new System.Drawing.Point(243, 31);
            this.btnGenre.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenre.Name = "btnGenre";
            this.btnGenre.Size = new System.Drawing.Size(100, 44);
            this.btnGenre.TabIndex = 3;
            this.btnGenre.Text = "Open Genre";
            this.btnGenre.UseVisualStyleBackColor = true;
            this.btnGenre.Click += new System.EventHandler(this.btnGenre_Click);
            // 
            // btnOrders
            // 
            this.btnOrders.Location = new System.Drawing.Point(243, 82);
            this.btnOrders.Margin = new System.Windows.Forms.Padding(4);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(100, 44);
            this.btnOrders.TabIndex = 4;
            this.btnOrders.Text = "Current Orders";
            this.btnOrders.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 239);
            this.Controls.Add(this.btnOrders);
            this.Controls.Add(this.btnGenre);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.lstGenres);
            this.Controls.Add(this.lblGenre);
            this.Margin = new System.Windows.Forms.Padding(4);
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

