﻿namespace IsraeliSuperMarketWinFormsApp
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
            this.productsDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.loadProductsPictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.compareButton = new System.Windows.Forms.Button();
            this.loadProductsButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.loadPricesPictureBox = new System.Windows.Forms.PictureBox();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.productsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadProductsPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadPricesPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // productsDataGridView
            // 
            this.productsDataGridView.AllowUserToAddRows = false;
            this.productsDataGridView.AllowUserToDeleteRows = false;
            this.productsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.productsDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.productsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.manufacturer,
            this.product,
            this.check});
            this.productsDataGridView.Location = new System.Drawing.Point(387, 12);
            this.productsDataGridView.Name = "productsDataGridView";
            this.productsDataGridView.Size = new System.Drawing.Size(505, 450);
            this.productsDataGridView.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(520, 465);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "טען, סמן מוצרים ולחץ על השוואת מחירים";
            // 
            // loadProductsPictureBox
            // 
            this.loadProductsPictureBox.Image = global::IsraeliSuperMarketWinFormsApp.Properties.Resources.loading;
            this.loadProductsPictureBox.Location = new System.Drawing.Point(507, 123);
            this.loadProductsPictureBox.Name = "loadProductsPictureBox";
            this.loadProductsPictureBox.Size = new System.Drawing.Size(256, 256);
            this.loadProductsPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.loadProductsPictureBox.TabIndex = 11;
            this.loadProductsPictureBox.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::IsraeliSuperMarketWinFormsApp.Properties.Resources.compare;
            this.pictureBox1.Location = new System.Drawing.Point(2, -7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 151);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // compareButton
            // 
            this.compareButton.BackgroundImage = global::IsraeliSuperMarketWinFormsApp.Properties.Resources.compare_button;
            this.compareButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.compareButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compareButton.Location = new System.Drawing.Point(188, 79);
            this.compareButton.Name = "compareButton";
            this.compareButton.Size = new System.Drawing.Size(193, 65);
            this.compareButton.TabIndex = 4;
            this.compareButton.UseVisualStyleBackColor = true;
            this.compareButton.Click += new System.EventHandler(this.compareButton_Click);
            // 
            // loadProductsButton
            // 
            this.loadProductsButton.BackgroundImage = global::IsraeliSuperMarketWinFormsApp.Properties.Resources.loadproducts;
            this.loadProductsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loadProductsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadProductsButton.Location = new System.Drawing.Point(188, 12);
            this.loadProductsButton.Name = "loadProductsButton";
            this.loadProductsButton.Size = new System.Drawing.Size(193, 65);
            this.loadProductsButton.TabIndex = 12;
            this.loadProductsButton.UseVisualStyleBackColor = true;
            this.loadProductsButton.Click += new System.EventHandler(this.loadProductsButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 150);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(369, 256);
            this.richTextBox1.TabIndex = 15;
            this.richTextBox1.Text = "";
            // 
            // loadPricesPictureBox
            // 
            this.loadPricesPictureBox.Image = global::IsraeliSuperMarketWinFormsApp.Properties.Resources.loading;
            this.loadPricesPictureBox.Location = new System.Drawing.Point(59, 150);
            this.loadPricesPictureBox.Name = "loadPricesPictureBox";
            this.loadPricesPictureBox.Size = new System.Drawing.Size(256, 256);
            this.loadPricesPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.loadPricesPictureBox.TabIndex = 16;
            this.loadPricesPictureBox.TabStop = false;
            // 
            // Id
            // 
            this.Id.HeaderText = "מספר מזהה";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // manufacturer
            // 
            this.manufacturer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.manufacturer.HeaderText = "יצרן";
            this.manufacturer.Name = "manufacturer";
            this.manufacturer.ReadOnly = true;
            // 
            // product
            // 
            this.product.HeaderText = "מוצר";
            this.product.Name = "product";
            this.product.ReadOnly = true;
            // 
            // check
            // 
            this.check.HeaderText = "סמן";
            this.check.Name = "check";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(220, 425);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 37);
            this.button1.TabIndex = 17;
            this.button1.Text = "Excel ייצוא ל";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 490);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.loadPricesPictureBox);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.loadProductsButton);
            this.Controls.Add(this.loadProductsPictureBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.compareButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.productsDataGridView);
            this.MaximumSize = new System.Drawing.Size(920, 529);
            this.MinimumSize = new System.Drawing.Size(920, 529);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.productsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadProductsPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadPricesPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView productsDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button compareButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox loadProductsPictureBox;
        private System.Windows.Forms.Button loadProductsButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.PictureBox loadPricesPictureBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn product;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
        private System.Windows.Forms.Button button1;
    }
}

