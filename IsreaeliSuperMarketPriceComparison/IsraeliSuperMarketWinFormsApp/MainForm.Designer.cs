namespace IsraeliSuperMarketWinFormsApp
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.productsDataGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.showImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.loadProductsPictureBox = new System.Windows.Forms.PictureBox();
            this.loadProductsButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.compareButton = new System.Windows.Forms.Button();
            this.smallLoadingPictureBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.resultDataGridView = new System.Windows.Forms.DataGridView();
            this.totalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.max3Prices = new System.Windows.Forms.DataGridViewImageColumn();
            this.min3Prices = new System.Windows.Forms.DataGridViewImageColumn();
            this.chainName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chainId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loadPricesPictureBox = new System.Windows.Forms.PictureBox();
            this.saveAsExcelButton = new System.Windows.Forms.Button();
            this.clearPriceComparisonResultsButton = new System.Windows.Forms.Button();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.saveCartButton = new System.Windows.Forms.Button();
            this.loadCartButton = new System.Windows.Forms.Button();
            this.selectAllButton = new System.Windows.Forms.Button();
            this.unSelectAllButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.productsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadProductsPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smallLoadingPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadPricesPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // productsDataGridView
            // 
            this.productsDataGridView.AllowUserToAddRows = false;
            this.productsDataGridView.AllowUserToDeleteRows = false;
            this.productsDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.productsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.manufacturer,
            this.showImage,
            this.product,
            this.quantity,
            this.check});
            this.productsDataGridView.Location = new System.Drawing.Point(957, 86);
            this.productsDataGridView.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.productsDataGridView.Name = "productsDataGridView";
            this.productsDataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.productsDataGridView.Size = new System.Drawing.Size(1536, 1086);
            this.productsDataGridView.TabIndex = 1;
            this.productsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.productsDataGridView_CellClick);
            this.productsDataGridView.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.productsDataGridView_CellMouseLeave);
            this.productsDataGridView.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.productsDataGridView_CellMouseMove);
            // 
            // Id
            // 
            this.Id.HeaderText = "מס\"ד";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 40;
            // 
            // manufacturer
            // 
            this.manufacturer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.manufacturer.HeaderText = "יצרן";
            this.manufacturer.Name = "manufacturer";
            this.manufacturer.ReadOnly = true;
            this.manufacturer.Width = 117;
            // 
            // showImage
            // 
            this.showImage.HeaderText = "תמונה";
            this.showImage.Name = "showImage";
            this.showImage.ReadOnly = true;
            this.showImage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.showImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.showImage.Width = 70;
            // 
            // product
            // 
            this.product.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.product.HeaderText = "מוצר";
            this.product.Name = "product";
            this.product.ReadOnly = true;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "הזן כמות";
            this.quantity.Name = "quantity";
            this.quantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.quantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.quantity.Width = 65;
            // 
            // check
            // 
            this.check.HeaderText = "סמן";
            this.check.Name = "check";
            this.check.Width = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1089, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1001, 52);
            this.label1.TabIndex = 21;
            this.label1.Text = " סמנו מוצרים, הזינו כמויות ולחצו על השוואת מחירים";
            // 
            // loadProductsPictureBox
            // 
            this.loadProductsPictureBox.Image = global::IsraeliSuperMarketWinFormsApp.Properties.Resources.loadingHeb;
            this.loadProductsPictureBox.Location = new System.Drawing.Point(1628, 582);
            this.loadProductsPictureBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.loadProductsPictureBox.Name = "loadProductsPictureBox";
            this.loadProductsPictureBox.Size = new System.Drawing.Size(220, 209);
            this.loadProductsPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loadProductsPictureBox.TabIndex = 20;
            this.loadProductsPictureBox.TabStop = false;
            // 
            // loadProductsButton
            // 
            this.loadProductsButton.AutoSize = true;
            this.loadProductsButton.BackgroundImage = global::IsraeliSuperMarketWinFormsApp.Properties.Resources.load;
            this.loadProductsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loadProductsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadProductsButton.Location = new System.Drawing.Point(569, 77);
            this.loadProductsButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.loadProductsButton.Name = "loadProductsButton";
            this.loadProductsButton.Size = new System.Drawing.Size(372, 103);
            this.loadProductsButton.TabIndex = 12;
            this.loadProductsButton.UseVisualStyleBackColor = true;
            this.loadProductsButton.Click += new System.EventHandler(this.loadProductsButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::IsraeliSuperMarketWinFormsApp.Properties.Resources.compare;
            this.pictureBox1.Location = new System.Drawing.Point(25, 101);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(468, 277);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // compareButton
            // 
            this.compareButton.BackgroundImage = global::IsraeliSuperMarketWinFormsApp.Properties.Resources.Comp;
            this.compareButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.compareButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compareButton.Location = new System.Drawing.Point(569, 194);
            this.compareButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.compareButton.Name = "compareButton";
            this.compareButton.Size = new System.Drawing.Size(372, 103);
            this.compareButton.TabIndex = 4;
            this.compareButton.UseVisualStyleBackColor = true;
            this.compareButton.Click += new System.EventHandler(this.compareButton_Click);
            // 
            // smallLoadingPictureBox
            // 
            this.smallLoadingPictureBox.Image = global::IsraeliSuperMarketWinFormsApp.Properties.Resources.smallLoading;
            this.smallLoadingPictureBox.Location = new System.Drawing.Point(981, 95);
            this.smallLoadingPictureBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.smallLoadingPictureBox.Name = "smallLoadingPictureBox";
            this.smallLoadingPictureBox.Size = new System.Drawing.Size(16, 16);
            this.smallLoadingPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.smallLoadingPictureBox.TabIndex = 23;
            this.smallLoadingPictureBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2259, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 52);
            this.label2.TabIndex = 24;
            this.label2.Text = "מוצרים :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(569, 357);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(324, 52);
            this.label3.TabIndex = 25;
            this.label3.Text = "תוצאת השוואה :";
            // 
            // resultDataGridView
            // 
            this.resultDataGridView.AllowUserToAddRows = false;
            this.resultDataGridView.AllowUserToDeleteRows = false;
            this.resultDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.resultDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.totalPrice,
            this.max3Prices,
            this.min3Prices,
            this.chainName,
            this.chainId});
            this.resultDataGridView.Location = new System.Drawing.Point(25, 416);
            this.resultDataGridView.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.resultDataGridView.Name = "resultDataGridView";
            this.resultDataGridView.ReadOnly = true;
            this.resultDataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.resultDataGridView.Size = new System.Drawing.Size(916, 756);
            this.resultDataGridView.TabIndex = 26;
            this.resultDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.resultDataGridView_CellClick);
            this.resultDataGridView.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.resultDataGridView_CellMouseLeave);
            this.resultDataGridView.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.resultDataGridView_CellMouseMove);
            // 
            // totalPrice
            // 
            this.totalPrice.HeaderText = "מחיר כולל";
            this.totalPrice.Name = "totalPrice";
            this.totalPrice.ReadOnly = true;
            this.totalPrice.Width = 50;
            // 
            // max3Prices
            // 
            this.max3Prices.HeaderText = "המוצרים היקרים";
            this.max3Prices.Name = "max3Prices";
            this.max3Prices.ReadOnly = true;
            this.max3Prices.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.max3Prices.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.max3Prices.Width = 70;
            // 
            // min3Prices
            // 
            this.min3Prices.HeaderText = "המוצרים הזולים";
            this.min3Prices.Name = "min3Prices";
            this.min3Prices.ReadOnly = true;
            this.min3Prices.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.min3Prices.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.min3Prices.Width = 70;
            // 
            // chainName
            // 
            this.chainName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.chainName.HeaderText = "ספק";
            this.chainName.Name = "chainName";
            this.chainName.ReadOnly = true;
            // 
            // chainId
            // 
            this.chainId.HeaderText = "מס\"ד";
            this.chainId.Name = "chainId";
            this.chainId.ReadOnly = true;
            this.chainId.Width = 40;
            // 
            // loadPricesPictureBox
            // 
            this.loadPricesPictureBox.Image = global::IsraeliSuperMarketWinFormsApp.Properties.Resources.loadingHeb;
            this.loadPricesPictureBox.Location = new System.Drawing.Point(379, 688);
            this.loadPricesPictureBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.loadPricesPictureBox.Name = "loadPricesPictureBox";
            this.loadPricesPictureBox.Size = new System.Drawing.Size(220, 209);
            this.loadPricesPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loadPricesPictureBox.TabIndex = 27;
            this.loadPricesPictureBox.TabStop = false;
            // 
            // saveAsExcelButton
            // 
            this.saveAsExcelButton.BackgroundImage = global::IsraeliSuperMarketWinFormsApp.Properties.Resources.SaveExcell;
            this.saveAsExcelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveAsExcelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveAsExcelButton.Location = new System.Drawing.Point(569, 1191);
            this.saveAsExcelButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.saveAsExcelButton.Name = "saveAsExcelButton";
            this.saveAsExcelButton.Size = new System.Drawing.Size(372, 103);
            this.saveAsExcelButton.TabIndex = 28;
            this.saveAsExcelButton.UseVisualStyleBackColor = true;
            this.saveAsExcelButton.Click += new System.EventHandler(this.saveAsExcelButton_Click);
            // 
            // clearPriceComparisonResultsButton
            // 
            this.clearPriceComparisonResultsButton.BackgroundImage = global::IsraeliSuperMarketWinFormsApp.Properties.Resources.Clear;
            this.clearPriceComparisonResultsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearPriceComparisonResultsButton.Location = new System.Drawing.Point(186, 1191);
            this.clearPriceComparisonResultsButton.Name = "clearPriceComparisonResultsButton";
            this.clearPriceComparisonResultsButton.Size = new System.Drawing.Size(372, 103);
            this.clearPriceComparisonResultsButton.TabIndex = 29;
            this.clearPriceComparisonResultsButton.UseVisualStyleBackColor = true;
            this.clearPriceComparisonResultsButton.Click += new System.EventHandler(this.clearPriceComparisonResultsButton_Click);
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.Location = new System.Drawing.Point(88, 48);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(117, 46);
            this.welcomeLabel.TabIndex = 30;
            this.welcomeLabel.Text = "שלום ";
            // 
            // saveCartButton
            // 
            this.saveCartButton.BackgroundImage = global::IsraeliSuperMarketWinFormsApp.Properties.Resources.SaveCart;
            this.saveCartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveCartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveCartButton.Location = new System.Drawing.Point(1528, 1191);
            this.saveCartButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.saveCartButton.Name = "saveCartButton";
            this.saveCartButton.Size = new System.Drawing.Size(372, 103);
            this.saveCartButton.TabIndex = 31;
            this.saveCartButton.UseVisualStyleBackColor = true;
            this.saveCartButton.Click += new System.EventHandler(this.saveCartButton_Click);
            // 
            // loadCartButton
            // 
            this.loadCartButton.BackgroundImage = global::IsraeliSuperMarketWinFormsApp.Properties.Resources.loadCart;
            this.loadCartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loadCartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadCartButton.Location = new System.Drawing.Point(1140, 1191);
            this.loadCartButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.loadCartButton.Name = "loadCartButton";
            this.loadCartButton.Size = new System.Drawing.Size(372, 103);
            this.loadCartButton.TabIndex = 32;
            this.loadCartButton.UseVisualStyleBackColor = true;
            this.loadCartButton.Click += new System.EventHandler(this.loadCartButton_Click);
            // 
            // selectAllButton
            // 
            this.selectAllButton.BackgroundImage = global::IsraeliSuperMarketWinFormsApp.Properties.Resources.SelectAlll;
            this.selectAllButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectAllButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectAllButton.Location = new System.Drawing.Point(2228, 1191);
            this.selectAllButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.selectAllButton.Name = "selectAllButton";
            this.selectAllButton.Size = new System.Drawing.Size(265, 103);
            this.selectAllButton.TabIndex = 33;
            this.selectAllButton.UseVisualStyleBackColor = true;
            this.selectAllButton.Click += new System.EventHandler(this.selectAllButton_Click);
            // 
            // unSelectAllButton
            // 
            this.unSelectAllButton.BackgroundImage = global::IsraeliSuperMarketWinFormsApp.Properties.Resources.unSelectAlll;
            this.unSelectAllButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.unSelectAllButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unSelectAllButton.Location = new System.Drawing.Point(1947, 1191);
            this.unSelectAllButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.unSelectAllButton.Name = "unSelectAllButton";
            this.unSelectAllButton.Size = new System.Drawing.Size(265, 103);
            this.unSelectAllButton.TabIndex = 34;
            this.unSelectAllButton.UseVisualStyleBackColor = true;
            this.unSelectAllButton.Click += new System.EventHandler(this.unSelectAllButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(2524, 1310);
            this.Controls.Add(this.unSelectAllButton);
            this.Controls.Add(this.selectAllButton);
            this.Controls.Add(this.loadCartButton);
            this.Controls.Add(this.saveCartButton);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.clearPriceComparisonResultsButton);
            this.Controls.Add(this.saveAsExcelButton);
            this.Controls.Add(this.loadPricesPictureBox);
            this.Controls.Add(this.resultDataGridView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.smallLoadingPictureBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loadProductsPictureBox);
            this.Controls.Add(this.loadProductsButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.compareButton);
            this.Controls.Add(this.productsDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(2556, 1398);
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "השוואת מחירי רשתות השיווק בישראל";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.productsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadProductsPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smallLoadingPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadPricesPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView productsDataGridView;
        private System.Windows.Forms.Button compareButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button loadProductsButton;
        private System.Windows.Forms.PictureBox loadProductsPictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox smallLoadingPictureBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView resultDataGridView;
        private System.Windows.Forms.PictureBox loadPricesPictureBox;
        private System.Windows.Forms.Button saveAsExcelButton;
        private System.Windows.Forms.Button clearPriceComparisonResultsButton;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturer;
        private System.Windows.Forms.DataGridViewImageColumn showImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn product;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
        private System.Windows.Forms.Button saveCartButton;
        private System.Windows.Forms.Button loadCartButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPrice;
        private System.Windows.Forms.DataGridViewImageColumn max3Prices;
        private System.Windows.Forms.DataGridViewImageColumn min3Prices;
        private System.Windows.Forms.DataGridViewTextBoxColumn chainName;
        private System.Windows.Forms.DataGridViewTextBoxColumn chainId;
        private System.Windows.Forms.Button selectAllButton;
        private System.Windows.Forms.Button unSelectAllButton;
    }
}

