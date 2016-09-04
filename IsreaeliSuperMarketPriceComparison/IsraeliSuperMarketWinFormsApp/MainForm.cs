using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using IsraeliSuperMarketManager;
using IsraeliSuperMarketModels;
using IsraeliSuperMarketWinFormsApp.Properties;

namespace IsraeliSuperMarketWinFormsApp
{
    public partial class MainForm : Form
    {
        private readonly SuperMarketManager _manager = new SuperMarketManager();
        private Tuple<Chain[], string[]> _compareResult;
        private IProduct[] _products;
        public MainForm()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private async void InitializeCustomComponents()
        {
            loadProductsPictureBox.Visible = false;
            loadPricesPictureBox.Visible = false;
            smallLoadingPictureBox.Visible = false;
            productsDataGridView.MultiSelect = true;
            MaximizeBox = false;
            productsDataGridView.Columns["check"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            productsDataGridView.Columns["quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            productsDataGridView.Columns["product"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            productsDataGridView.Columns["manufacturer"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            productsDataGridView.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            productsDataGridView.Columns["showImage"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            resultDataGridView.Columns["chainId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            resultDataGridView.Columns["chainName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            resultDataGridView.Columns["min3Prices"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            resultDataGridView.Columns["max3Prices"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            resultDataGridView.Columns["totalPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            await LoadAllProducts();
        }

        private async void loadProductsButton_Click(object sender, EventArgs e)
        {
            productsDataGridView.Rows.Clear();
            productsDataGridView.Refresh();
            await LoadAllProducts();
        }

        private async Task LoadAllProducts()
        {
            loadProductsPictureBox.Visible = true;
            var products = await _manager.GetProductsAsync();
            _products = products;
            foreach (var product1 in products)
            {
                productsDataGridView.Rows.Add("הצג תמונה", product1.Id, product1.Manufacturer, product1.Name, 1, 0);
            }
            loadProductsPictureBox.Visible = false;
        }

        private async void compareButton_Click(object sender, EventArgs e)
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
            if (!IsAnyWrongQuantity())
            {
                return;
            }
            resultDataGridView.Rows.Clear();
            resultDataGridView.Refresh();
            loadPricesPictureBox.Visible = true;
            var result = await _manager.ComparePricesAsync(GetCheckedProducts());
            _compareResult = result;
            var i = 0;
            foreach (var chain in result.Item1)
            {
                resultDataGridView.Rows.Add(result.Item2[i], "הצג", "הצג", chain.Name, chain.Id);
                ++i;
            }
            loadPricesPictureBox.Visible = false;
        }

        private bool IsAnyWrongQuantity()
        {
            foreach (DataGridViewRow row in productsDataGridView.Rows)
            {
                if (_products.Single(p => p.Id == int.Parse(row.Cells["Id"].Value.ToString())).IsWeighted)
                {
                    double doubleQuantity;
                    if (double.TryParse(row.Cells["quantity"].Value.ToString(), out doubleQuantity)) continue;
                    MessageBox.Show($"Wrong Quantity of product id = {row.Cells["Id"].Value}");
                    return false;
                }
                else
                {
                    int intQuantity;
                    if (int.TryParse(row.Cells["quantity"].Value.ToString(), out intQuantity)) continue;
                    MessageBox.Show($"Wrong Quantity of product id = {row.Cells["Id"].Value}");
                    return false;
                }
            }
            return true;
        }

        private Product[] GetCheckedProducts()
        {
            var products = new List<Product>();
            foreach (DataGridViewRow row in productsDataGridView.Rows)
            {
                var cell = row.Cells["check"] as DataGridViewCheckBoxCell;
                var isChecked = cell != null && (cell.Value as bool? ?? false);
                if (!isChecked) continue;
                var id = int.Parse(row.Cells["Id"].Value.ToString());
                var productQuantity = double.Parse(row.Cells["quantity"].Value.ToString());
                products.Add(new Product { Id = id , Name = row.Cells["product"].Value.ToString(), Manufacturer = row.Cells["manufacturer"].Value.ToString(), Quantity = productQuantity });
            }
            return products.ToArray();
        }

        private bool IsAnyProductChecked()
        {
            if ((from DataGridViewRow row in productsDataGridView.Rows
                 select row.Cells["check"] as DataGridViewCheckBoxCell 
                 into cell
                 select cell != null && (cell.Value as bool? ?? false))
                 .Any(isChecked => isChecked))
            {
                return true;
            }
            MessageBox.Show(@"נא בחר/י לפחות מוצר אחד");
            return false;
        }

        private async void productsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridViewColumn = productsDataGridView.Columns["showImage"];
            if (dataGridViewColumn != null && (e.ColumnIndex != dataGridViewColumn.Index || e.RowIndex < 0))
            {
                return;
            }
            smallLoadingPictureBox.Visible = true;
            var imageName = productsDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString();
            using (var form = new Form())
            {
                var image = await _manager.GetImageAsync(int.Parse(imageName));
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Size = new Size(image.Width + 18, image.Height + 40);
                form.MaximumSize = form.Size;
                form.MinimumSize = form.Size;
                form.MaximizeBox = false;
                form.Icon = Resources.icon;
                var pb = new PictureBox
                {
                    Dock = DockStyle.Fill,
                    Image = image
                };
                form.Controls.Add(pb);
                smallLoadingPictureBox.Visible = false;
                form.ShowDialog();
            }
        }

        private void resultDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridViewMax3Column = resultDataGridView.Columns["max3Prices"];
            var dataGridViewMin3Column = resultDataGridView.Columns["min3Prices"];
            if (dataGridViewMax3Column != null && dataGridViewMin3Column != null && ( (e.ColumnIndex != dataGridViewMax3Column.Index && e.ColumnIndex != dataGridViewMin3Column.Index) || e.RowIndex < 0))
            {
                return;
            }
            var id = int.Parse(resultDataGridView.Rows[e.RowIndex].Cells["chainId"].Value.ToString());
            using (var form = new Form())
            {
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Size = new Size(600, 300);
                form.MaximumSize = form.Size;
                form.MinimumSize = form.Size;
                form.MaximizeBox = false;
                form.Icon = Resources.icon;
                var tb = new RichTextBox
                {
                    Text = string.Empty,
                    ReadOnly = true,
                    Size = new Size(575, 265),
                    Location = new Point(5, 5)
            };
                if (dataGridViewMax3Column?.Index == e.ColumnIndex)
                {
                    foreach (var p in _compareResult.Item1.Single(chain => chain.Id == id).Max3Products)
                    {
                        tb.Text += $"Id = {p.Id}, Name = {p.Name}, Price = {p.Price}\n";
                    }
                }
                else
                {
                    foreach (var p in _compareResult.Item1.Single(chain => chain.Id == id).Min3Products)
                    {
                        tb.Text += $"Id = {p.Id}, Name = {p.Name}, Price = {p.Price}\n";
                    }
                }
                form.Controls.Add(tb);
                form.ShowDialog();
            }
        }
    }
}
