using System.Windows.Forms;
using IsraeliSuperMarketManager;

namespace IsraeliSuperMarketWinFormsApp
{
    public partial class Form1 : Form
    {
        private readonly SuperMarketManager _manager = new SuperMarketManager();
        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            loadProductsPictureBox.Visible = false;
            loadPricesPictureBox.Visible = false;
        }

        private async void loadProductsButton_Click(object sender, System.EventArgs e)
        {
            loadProductsPictureBox.Visible = true;
            productsDataGridView.Rows.Clear();
            productsDataGridView.Refresh();
            var products = await _manager.GetProductsAsync();
            foreach (var product1 in products)
            {
                productsDataGridView.Rows.Add(product1.Id, product1.Manufacturer, product1.Name, 0);
            }
            loadProductsPictureBox.Visible = false;
        }

        private void compareButton_Click(object sender, System.EventArgs e)
        {
            var isAnyProductChecked = false;
            foreach (DataGridViewRow row in productsDataGridView.Rows)
            {
                var checkCell = row.Cells["check"].Value;
                if ((int)checkCell == 1)
                {
                    isAnyProductChecked = true;
                    break;
                }
            }
            if (!isAnyProductChecked)
            {
                MessageBox.Show(@"נא בחר/י לפחות מוצר אחד");
                return;
            }
        }
    }
}
