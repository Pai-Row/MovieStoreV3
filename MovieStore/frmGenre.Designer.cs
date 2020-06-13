namespace MovieStore
{
    partial class frmGenre
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
            this.lblTags = new System.Windows.Forms.Label();
            this.lstMovies = new System.Windows.Forms.ListBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cbRelease = new System.Windows.Forms.ComboBox();
            this.lblReturn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTags
            // 
            this.lblTags.AutoSize = true;
            this.lblTags.Location = new System.Drawing.Point(16, 11);
            this.lblTags.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTags.Name = "lblTags";
            this.lblTags.Size = new System.Drawing.Size(309, 17);
            this.lblTags.TabIndex = 0;
            this.lblTags.Text = "Tags: Supernatural, Jumpscares, Bloody, Scary";
            // 
            // lstMovies
            // 
            this.lstMovies.FormattingEnabled = true;
            this.lstMovies.ItemHeight = 16;
            this.lstMovies.Items.AddRange(new object[] {
            "Paranormal Activity\t\t$4\t5\t8 Days",
            "REC\t\t\t$5\t3\t5 Days",
            "The Conjuring\t\t$6\t2\t3 Days"});
            this.lstMovies.Location = new System.Drawing.Point(20, 54);
            this.lstMovies.Margin = new System.Windows.Forms.Padding(4);
            this.lstMovies.Name = "lstMovies";
            this.lstMovies.Size = new System.Drawing.Size(757, 212);
            this.lstMovies.TabIndex = 1;
            this.lstMovies.DoubleClick += new System.EventHandler(this.lstMovies_DoubleClick);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(16, 34);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(35, 17);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Title";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(207, 34);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(52, 17);
            this.lblPrice.TabIndex = 3;
            this.lblPrice.Text = "Price $";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(268, 34);
            this.lblQuantity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(61, 17);
            this.lblQuantity.TabIndex = 4;
            this.lblQuantity.Text = "Quantity";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(159, 274);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(131, 28);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete Movie";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(20, 274);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(131, 28);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add Movie";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // lblEdit
            // 
            this.lblEdit.Location = new System.Drawing.Point(297, 274);
            this.lblEdit.Margin = new System.Windows.Forms.Padding(4);
            this.lblEdit.Name = "lblEdit";
            this.lblEdit.Size = new System.Drawing.Size(131, 28);
            this.lblEdit.TabIndex = 5;
            this.lblEdit.Text = "Edit Movie";
            this.lblEdit.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(648, 274);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(131, 28);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // cbRelease
            // 
            this.cbRelease.FormattingEnabled = true;
            this.cbRelease.Location = new System.Drawing.Point(436, 277);
            this.cbRelease.Margin = new System.Windows.Forms.Padding(4);
            this.cbRelease.Name = "cbRelease";
            this.cbRelease.Size = new System.Drawing.Size(160, 24);
            this.cbRelease.TabIndex = 7;
            this.cbRelease.Text = "Rentable";
            // 
            // lblReturn
            // 
            this.lblReturn.AutoSize = true;
            this.lblReturn.Location = new System.Drawing.Point(339, 34);
            this.lblReturn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReturn.Name = "lblReturn";
            this.lblReturn.Size = new System.Drawing.Size(85, 17);
            this.lblReturn.TabIndex = 8;
            this.lblReturn.Text = "Return Date";
            // 
            // frmGenre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 318);
            this.Controls.Add(this.lblReturn);
            this.Controls.Add(this.cbRelease);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lstMovies);
            this.Controls.Add(this.lblTags);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmGenre";
            this.Text = "Movies - Horror";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTags;
        private System.Windows.Forms.ListBox lstMovies;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button lblEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cbRelease;
        private System.Windows.Forms.Label lblReturn;
    }
}