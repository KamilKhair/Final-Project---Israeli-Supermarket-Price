using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using IsraeliSuperMarketManager;
using IsraeliSuperMarketModels;
using IsraeliSuperMarketWinFormsApp.Properties;
using Excel = Microsoft.Office.Interop.Excel;

namespace IsraeliSuperMarketWinFormsApp
{
    public partial class MainForm : Form
    {
        private readonly SuperMarketManager _manager = new SuperMarketManager();
        private Tuple<IEnumerable<Chain>, IEnumerable<string>> _compareResult;
        private IEnumerable<IProduct> _products;
        private bool _isLoadingProducts;
        private bool _isComparingPrices;
        private bool _isLoadingImage;
        private readonly Form _logInForm;
        private readonly IUser _user;

        public MainForm(Form logInForm, IUser user)
        {
            _logInForm = logInForm;
            _user = user;
            InitializeComponent();
            InitializeCustomComponents();
        }

        private async void InitializeCustomComponents()
        {
            welcomeLabel.Text += $@" {_user.FirstName}";
            welcomeLabel.Text += $@" {_user.LastName}";
            loadProductsPictureBox.Visible = false;
            loadPricesPictureBox.Visible = false;
            smallLoadingPictureBox.Visible = false;
            productsDataGridView.MultiSelect = true;
            InitializeProductsDataGridView();
            InitializeResultDataGridView();
            _isComparingPrices = false;
            await LoadAllProducts();
        }

        private void InitializeResultDataGridView()
        {
            var resultGridViewChainIdColumn = resultDataGridView.Columns["chainId"];
            if (resultGridViewChainIdColumn != null)
            {
                resultGridViewChainIdColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            var resultGridViewNameColumn = resultDataGridView.Columns["chainName"];
            if (resultGridViewNameColumn != null)
            {
                resultGridViewNameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            var resultGridViewMinPricesColumn = resultDataGridView.Columns["min3Prices"];
            if (resultGridViewMinPricesColumn != null)
            {
                resultGridViewMinPricesColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            var resultGridViewMaxPricesColumn = resultDataGridView.Columns["max3Prices"];
            if (resultGridViewMaxPricesColumn != null)
            {
                resultGridViewMaxPricesColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            var resultGridViewTotalPriceColumn = resultDataGridView.Columns["totalPrice"];
            if (resultGridViewTotalPriceColumn != null)
            {
                resultGridViewTotalPriceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void InitializeProductsDataGridView()
        {
            var dataGridViewCheckColumn = productsDataGridView.Columns["check"];
            if (dataGridViewCheckColumn != null)
            {
                dataGridViewCheckColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            var dataGridViewQuantityColumn = productsDataGridView.Columns["quantity"];
            if (dataGridViewQuantityColumn != null)
            {
                dataGridViewQuantityColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            var dataGridViewProductColumn = productsDataGridView.Columns["product"];
            if (dataGridViewProductColumn != null)
            {
                dataGridViewProductColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            var dataGridViewManufacturerColumn = productsDataGridView.Columns["manufacturer"];
            if (dataGridViewManufacturerColumn != null)
            {
                dataGridViewManufacturerColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            var dataGridViewIdColumn = productsDataGridView.Columns["Id"];
            if (dataGridViewIdColumn != null)
            {
                dataGridViewIdColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            var dataGridViewImageColumn = productsDataGridView.Columns["showImage"];
            if (dataGridViewImageColumn != null)
            {
                dataGridViewImageColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private async void loadProductsButton_Click(object sender, EventArgs e)
        {
            if (_isLoadingProducts)
            {
                MessageBox.Show(@"טוען מוצרים, נא להמתין");
                return;
            }
            productsDataGridView.Rows.Clear();
            productsDataGridView.Refresh();
            await LoadAllProducts();
        }

        private async Task LoadAllProducts()
        {
            _isLoadingProducts = true;
            loadProductsPictureBox.Visible = true;
            try
            {
                var products = await _manager.GetProductsAsync();
                _products = products as IList<IProduct> ?? products.ToList();
                FillProductsDataGridView(_products);
            }
            catch (Exception)
            {
                MessageBox.Show(@"  שגיאה בטעינת המוצרים מהשרת");
            }
            _isLoadingProducts = false;
            loadProductsPictureBox.Visible = false;
        }

        private void FillProductsDataGridView(IEnumerable<IProduct> products)
        {
            foreach (var product1 in products)
            {
                productsDataGridView.Rows.Add(product1.Id, product1.Manufacturer, Resources.showimg, product1.Name, 1,
                    0);
            }
        }

        private async void compareButton_Click(object sender, EventArgs e)
        {
            if (_isComparingPrices)
            {
                MessageBox.Show(@"מתבצעת פעולת השוואת מחירים, נא להמתין");
                return;
            }
            if (productsDataGridView.Rows.Count <= 0)
            {
                MessageBox.Show(@"נא לטעון מוצרים קודם");
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

            _isComparingPrices = true;
            resultDataGridView.Rows.Clear();
            resultDataGridView.Refresh();
            loadPricesPictureBox.Visible = true;
            try
            {
                var result = await _manager.ComparePricesAsync(GetCheckedProducts());
                _compareResult = result;
                FillResultDataGridView(result);
            }
            catch (Exception)
            {
                MessageBox.Show(@"  שגיאה בתקשורת עם השרת");
            }
            loadPricesPictureBox.Visible = false;
            _isComparingPrices = false;
            _isLoadingProducts = false;
        }

        private void FillResultDataGridView(Tuple<IEnumerable<Chain>, IEnumerable<string>> result)
        {
            var i = 0;
            foreach (var chain in result.Item1)
            {
                resultDataGridView.Rows.Add(result.Item2.ElementAt(i), Resources.showw, Resources.showw, chain.Name,
                    chain.Id);
                ++i;
            }
        }

        private bool IsAnyWrongQuantity()
        {
            foreach (DataGridViewRow row in productsDataGridView.Rows)
            {
                if (_products.Single(p => p.Id == int.Parse(row.Cells["Id"].Value.ToString())).IsWeighted)
                {
                    double doubleQuantity;
                    if (double.TryParse(row.Cells["quantity"].Value.ToString(), out doubleQuantity)) continue;
                    MessageBox.Show($@"{row.Cells["Id"].Value} נא להזין כמות חוקית עבור מוצר מספר");
                    return false;
                }
                int intQuantity;
                if (int.TryParse(row.Cells["quantity"].Value.ToString(), out intQuantity)) continue;
                MessageBox.Show($@"{row.Cells["Id"].Value} נא להזין כמות חוקית עבור מוצר מספר");
                return false;
            }
            return true;
        }

        private IEnumerable<Product> GetCheckedProducts()
        {
            return (from DataGridViewRow row in productsDataGridView.Rows
                let cell = row.Cells["check"] as DataGridViewCheckBoxCell
                let isChecked = cell != null && (cell.Value as bool? ?? false)
                where isChecked
                select new Product
                {
                    Id = int.Parse(row.Cells["Id"].Value.ToString()),
                    Name = row.Cells["product"].Value.ToString(),
                    Manufacturer = row.Cells["manufacturer"].Value.ToString(),
                    Quantity = double.Parse(row.Cells["quantity"].Value.ToString())
                }).ToArray();
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
            MessageBox.Show(@"נא לבחור לפחות מוצר אחד");
            return false;
        }

        private async void productsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_isLoadingImage)
            {
                return;
            }
            var dataGridViewColumn = productsDataGridView.Columns["showImage"];
            if (dataGridViewColumn != null && (e.ColumnIndex != dataGridViewColumn.Index || e.RowIndex < 0))
            {
                return;
            }
            _isLoadingImage = true;
            smallLoadingPictureBox.Visible = true;
            var imageName = productsDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString();
            using (var imageForm = new Form())
            {
                try
                {
                    var image = await _manager.GetImageAsync(int.Parse(imageName));
                    imageForm.StartPosition = FormStartPosition.CenterScreen;
                    imageForm.Size = new Size(image.Width, image.Height + 40);
                    imageForm.MaximumSize = imageForm.Size;
                    imageForm.MinimumSize = imageForm.Size;
                    imageForm.MaximizeBox = false;
                    imageForm.Icon = Resources.icon;
                    var pb = new PictureBox
                    {
                        Dock = DockStyle.Fill,
                        Image = image
                    };
                    imageForm.Controls.Add(pb);
                    smallLoadingPictureBox.Visible = false;
                    imageForm.ShowDialog();
                }
                catch (Exception)
                {
                    MessageBox.Show(@"  שגיאה בתקשורת עם השרת");
                }
                finally
                {
                    smallLoadingPictureBox.Visible = false;
                    _isLoadingImage = false;
                }
            }
        }

        private void resultDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridViewMax3Column = resultDataGridView.Columns["max3Prices"];
            var dataGridViewMin3Column = resultDataGridView.Columns["min3Prices"];
            if (dataGridViewMax3Column != null && dataGridViewMin3Column != null &&
                ((e.ColumnIndex != dataGridViewMax3Column.Index && e.ColumnIndex != dataGridViewMin3Column.Index) ||
                 e.RowIndex < 0))
            {
                return;
            }
            var id = int.Parse(resultDataGridView.Rows[e.RowIndex].Cells["chainId"].Value.ToString());
            var nameOfChain = resultDataGridView.Rows[e.RowIndex].Cells["chainName"].Value.ToString();
            ShowPricesForm(e, dataGridViewMax3Column, id, nameOfChain);
        }

        private void ShowPricesForm(DataGridViewCellEventArgs e, DataGridViewBand dataGridViewMax3Column, int id,
            string nameOfChain)
        {
            using (var pricesForm = new Form())
            {
                pricesForm.StartPosition = FormStartPosition.CenterScreen;
                pricesForm.AutoSize = true;
                pricesForm.MaximizeBox = false;
                pricesForm.Icon = Resources.icon;

                var idCol = new DataGridViewTextBoxColumn
                {
                    HeaderText = @"מס""ד",
                    ReadOnly = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                };
                var nameCol = new DataGridViewTextBoxColumn
                {
                    HeaderText = @"שם מוצר",
                    ReadOnly = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                };
                var quantityCol = new DataGridViewTextBoxColumn
                {
                    HeaderText = @"כמות",
                    ReadOnly = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                };
                var priceCol = new DataGridViewTextBoxColumn
                {
                    HeaderText = @"מחיר",
                    ReadOnly = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                };

                var pricesDataGridView = new DataGridView
                {
                    AllowUserToAddRows = false,
                    AllowUserToDeleteRows = false,
                    BackgroundColor = SystemColors.Control,
                    ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                };
                pricesDataGridView.Columns.AddRange(priceCol, quantityCol, nameCol, idCol);
                pricesDataGridView.Location = new Point(3, 3);
                pricesDataGridView.Margin = new Padding(8, 7, 8, 7);
                pricesDataGridView.RightToLeft = RightToLeft.No;
                pricesDataGridView.TabIndex = 1;
                if (dataGridViewMax3Column?.Index == e.ColumnIndex)
                {
                    pricesForm.Text = @"המוצרים היקרים" + $@" - {nameOfChain}";
                    foreach (
                        var p in
                        _compareResult.Item1.Single(chain => chain.Id == id)
                            .Products.OrderByDescending(p => p.Price)
                            .Take(3))
                    {
                        pricesDataGridView.Rows.Add(p.Price, p.Quantity, p.Name, p.Id);
                    }
                }
                else
                {
                    pricesForm.Text = @"המוצרים הזולים" + $@" - {nameOfChain}";
                    foreach (
                        var p in
                        _compareResult.Item1.Single(chain => chain.Id == id).Products.OrderBy(p => p.Price).Take(3))
                    {
                        pricesDataGridView.Rows.Add(p.Price, p.Quantity, p.Name, p.Id);
                    }
                }
                pricesDataGridView.Size = new Size(
                    idCol.Width + nameCol.Width + quantityCol.Width + priceCol.Width + 15,
                    pricesDataGridView.Rows.Count*28 + 35);
                pricesForm.Controls.Add(pricesDataGridView);
                pricesForm.Size = pricesDataGridView.Size;
                pricesForm.MaximumSize = pricesForm.Size;
                pricesForm.MinimumSize = pricesForm.Size;
                pricesForm.ShowDialog();
            }
        }

        private void saveAsExcelButton_Click(object sender, EventArgs e)
        {
            if (resultDataGridView.Rows.Count <= 0)
            {
                MessageBox.Show(@"נא לבצע פעולת השוואת מחירים קודם");
                return;
            }
            var sfd = new SaveFileDialog
            {
                Filter = @"Excel files (*.xls)|*.xls|All files (*.*)|*.*",
                Title = @"Save an Excel File",
                FilterIndex = 1,
                RestoreDirectory = true,
                FileName = "ISMC-Graph",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SaveExcelFile(sfd);
            }
        }

        private void SaveExcelFile(FileDialog sfd)
        {
            if (sfd.FileName.Length <= 0)
            {
                return;
            }

            Task.Factory.StartNew(() =>
            {
                object misValue = System.Reflection.Missing.Value;
                var xlApp = new Excel.Application();
                var xlWorkBook = xlApp.Workbooks.Add(misValue);

                AddAllChainsSheet(xlWorkBook);

                var chainColN = 2;
                foreach (var chain in _compareResult.Item1)
                {
                    AddNewChainSheet(xlWorkBook, chainColN, chain);
                    ++chainColN;
                }

                xlWorkBook.SaveAs(sfd.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue,
                    misValue,
                    Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
            });
        }

        private void AddAllChainsSheet(Excel._Workbook xlWorkBook)
        {
            var xlWorkSheet = (Excel.Worksheet) xlWorkBook.Worksheets.Item[1];
            xlWorkSheet.Name = "כל הרשתות";

            xlWorkSheet.Cells[1, 1] = "";
            var chainCol = 2;
            foreach (var chain in _compareResult.Item1)
            {
                xlWorkSheet.Cells[1, chainCol] = chain.Name;
                var i = 2;
                foreach (var productInChain in chain.Products)
                {
                    xlWorkSheet.Cells[i, 1] = productInChain.Name + $" כמות - {productInChain.Quantity}";
                    xlWorkSheet.Cells[i, chainCol] = productInChain.Price;
                    ++i;
                }
                chainCol++;
            }
            var xlCharts = (Excel.ChartObjects) xlWorkSheet.ChartObjects(Type.Missing);
            var myChart = xlCharts.Add(230, 1, 800, 450);
            var chartPage = myChart.Chart;
            var productsRange = "D" + (_compareResult.Item1.ElementAt(0).Products.Count() + 1);
            var chartRange = xlWorkSheet.Range["A1", productsRange];
            chartPage.ChartWizard(chartRange, Title: "כל הרשתות", ValueTitle: "מחיר");
            chartPage.ChartType = Excel.XlChartType.xl3DBarClustered;
        }

        private void AddNewChainSheet(Excel._Workbook xlWorkBook, int chainColN, IChain chain)
        {
            xlWorkBook.Sheets.Add(After: xlWorkBook.Sheets[xlWorkBook.Sheets.Count]);
            var xlWorkSheetN = (Excel.Worksheet) xlWorkBook.Worksheets.Item[chainColN];
            xlWorkSheetN.Name = chain.Name;
            xlWorkSheetN.Cells[1, 1] = "";
            xlWorkSheetN.Cells[1, 2] = chain.Name;
            var i = 2;
            var productsOrderedByPrice = chain.Products.OrderBy(p => p.Price);
            foreach (var productInChain in productsOrderedByPrice)
            {
                xlWorkSheetN.Cells[i, 1] = productInChain.Name + $" כמות - {productInChain.Quantity}";
                xlWorkSheetN.Cells[i, 2] = productInChain.Price;
                ++i;
            }
            var xlChartsN = (Excel.ChartObjects) xlWorkSheetN.ChartObjects(Type.Missing);
            var myChartN = xlChartsN.Add(230, 1, 800, 450);
            var chartPageN = myChartN.Chart;
            var productsRangeN = "B" + (_compareResult.Item1.ElementAt(chainColN - 2).Products.Count() + 1);
            var chartRangeN = xlWorkSheetN.Range["A1", productsRangeN];
            chartPageN.ChartWizard(chartRangeN, Title: chain.Name, ValueTitle: "מחיר");
            chartPageN.ChartType = Excel.XlChartType.xl3DBarClustered;
        }

        private void clearPriceComparisonResultsButton_Click(object sender, EventArgs e)
        {
            resultDataGridView.Rows.Clear();
            resultDataGridView.Refresh();
        }

        private void productsDataGridView_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0)
            {
                return;
            }
            productsDataGridView.Cursor =
                productsDataGridView.Columns[e.ColumnIndex] == productsDataGridView.Columns["showImage"]
                    ? Cursors.Hand
                    : Cursors.Default;
        }

        private void productsDataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            productsDataGridView.Cursor = Cursors.Default;
        }

        private void resultDataGridView_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0)
            {
                return;
            }
            var max3PricesCol = resultDataGridView.Columns["max3Prices"];
            var min3PricesCol = resultDataGridView.Columns["min3Prices"];
            resultDataGridView.Cursor =
                min3PricesCol != null && max3PricesCol != null &&
                (e.ColumnIndex == max3PricesCol.Index || e.ColumnIndex == min3PricesCol.Index)
                    ? Cursors.Hand
                    : Cursors.Default;
        }

        private void resultDataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            resultDataGridView.Cursor = Cursors.Default;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var dr = MessageBox.Show(@"? האם את\ה רוצה להתחבר מחדש",
                @"יציאה", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    _logInForm.Show();
                    break;
                case DialogResult.No:
                    _logInForm.Close();
                    _logInForm.Dispose();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void saveCartButton_Click(object sender, EventArgs e)
        {
            if (productsDataGridView.Rows.Count <= 0)
            {
                MessageBox.Show(@"נא לטעון מוצרים");
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
            var saveCartDialog = new SaveFileDialog
            {
                Filter = @"txt files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,
                FileName = "ISMC-Cart"
            };
            if (saveCartDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            var checkedProducts = GetCheckedProducts();
            using (var file = new StreamWriter(saveCartDialog.FileName))
            {
                foreach (var checkedProduct in checkedProducts)
                {
                    file.WriteLine($"{checkedProduct.Id} {checkedProduct.Quantity}");
                }
            }
        }

        private void loadCartButton_Click(object sender, EventArgs e)
        {
            var loadCratDialog = new OpenFileDialog
            {
                Title = @"Open Cart Text File",
                Filter = @"TXT files|*.txt",
            };
            if (loadCratDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            try
            {
                using (var file = new StreamReader(loadCratDialog.FileName))
                {
                    var ids = new List<int>();
                    var quantities = new List<double>();
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        var splits = line.Split(' ');
                        int id;
                        if (!int.TryParse(splits[0], out id))
                        {
                            MessageBox.Show(@"הקובץ הינו פגום");
                            return;
                        }
                        ids.Add(id);
                        double qty;
                        if (!double.TryParse(splits[1], out qty))
                        {
                            MessageBox.Show(@"הקובץ הינו פגום");
                            return;
                        }
                        quantities.Add(qty);
                    }
                    if (!IsAllProductsInCartUpToDate(ids))
                    {
                        MessageBox.Show(@"חלק מהמוצרים בסל שבחרת אינם עדכניים, נא ליצור סל חדש");
                        return;
                    }
                    productsDataGridView.Rows.Clear();
                    productsDataGridView.Refresh();
                    foreach (var product1 in _products)
                    {
                        if (ids.Any(id => id == product1.Id))
                        {
                            productsDataGridView.Rows.Add(product1.Id, product1.Manufacturer, Resources.showimg,
                                product1.Name, quantities[ids.IndexOf(product1.Id)],
                                true);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"שגיאה בקריאת הקובץ");
            }
        }

        private bool IsAllProductsInCartUpToDate(IEnumerable<int> ids)
        {
            return ids.All(id => _products.Any(p => p.Id == id));
        }

        private void selectAllButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in productsDataGridView.Rows)
            {
                row.Cells["check"].Value = true;
            }
        }

        private void unSelectAllButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in productsDataGridView.Rows)
            {
                row.Cells["check"].Value = 0;
            }
        }
    }
}
