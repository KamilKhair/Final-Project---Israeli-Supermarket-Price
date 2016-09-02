﻿using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IsraeliSuperMarketManager;
using IsraeliSuperMarketWinFormsApp.Properties;

namespace IsraeliSuperMarketWinFormsApp
{
    public partial class MainForm : Form
    {
        private readonly SuperMarketManager _manager = new SuperMarketManager();
        public MainForm()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            loadProductsPictureBox.Visible = false;
            loadPricesPictureBox.Visible = false;
            productsDataGridView.MultiSelect = true;
            this.MaximizeBox = false;
        }

        private async void loadProductsButton_Click(object sender, System.EventArgs e)
        {
            loadProductsPictureBox.Visible = true;
            productsDataGridView.Rows.Clear();
            productsDataGridView.Refresh();
            var products = await _manager.GetProductsAsync();
            foreach (var product1 in products)
            {
                productsDataGridView.Rows.Add("הצג תמונה", product1.Id, product1.Manufacturer, product1.Name, 0);
            }
            loadProductsPictureBox.Visible = false;
        }

        private void compareButton_Click(object sender, System.EventArgs e)
        {
            if (productsDataGridView.Rows.Count <= 0)
            {
                MessageBox.Show(@"נא טען/טעני מוצרים קודם");
                return;
            }
            if (!IsAnyProductChecked())
            {
                return;
            }
        }

        private bool IsAnyProductChecked()
        {
            var isAnyProductChecked = false;
            foreach (DataGridViewRow row in productsDataGridView.Rows)
            {
                var cell = row.Cells["check"] as DataGridViewCheckBoxCell;
                var isChecked = cell != null && (cell.Value as bool? ?? false);
                if (isChecked)
                {
                    isAnyProductChecked = true;
                }
            }
            if (isAnyProductChecked) return true;
            MessageBox.Show(@"נא בחר/י לפחות מוצר אחד");
            return false;
        }

        private async void showChainsButton_Click(object sender, System.EventArgs e)
        {
            var chains = await _manager.GetChainsAsync();
            var chainsStringBuilder = new StringBuilder();
            foreach (var chain in chains)
            {
                chainsStringBuilder.AppendLine(chain.ToString());
            }
            MessageBox.Show(chainsStringBuilder.ToString());
        }

        private void excelButton_Click(object sender, System.EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            var saveFileDialog1 = new SaveFileDialog
            {
                Filter = "Execl files (*.xls)|*.xls",
                Title = "Save an Excel File"
            };
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName == "")
            {
                return;
            }
            // Saves the Image via a FileStream created by the OpenFile method.
            var fs =
                (System.IO.FileStream)saveFileDialog1.OpenFile();
            // Saves the Image in the appropriate ImageFormat based upon the
            // File type selected in the dialog box.
            // NOTE that the FilterIndex property is one-based.
            if (saveFileDialog1.FilterIndex == 1)
            {
                this.excelButton.Image.Save(fs,
                    System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            fs.Close();
        }

        private async void productsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridViewColumn = productsDataGridView.Columns["showImage"];
            if (dataGridViewColumn != null && (e.ColumnIndex != dataGridViewColumn.Index || e.RowIndex < 0))
            {
                return;
            }
            var imageName = productsDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString();
            using (var form = new Form())
            {
                try
                {
                    var image = await _manager.GetImageAsync(int.Parse(imageName));
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.Size = new Size(image.Width + 18, image.Height + 40);
                    form.MaximizeBox = false;
                    form.Icon = Resources.icon;
                    var pb = new PictureBox
                    {
                        Dock = DockStyle.Fill,
                        Image = image
                    };
                    form.Controls.Add(pb);
                    form.ShowDialog();

                }
                catch (System.IO.FileNotFoundException)
                {
                    MessageBox.Show("There was an error opening the bitmap." +
                                    "Please check the path.");
                }
            }
        }
    }
}