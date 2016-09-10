using System;
using System.Windows.Forms;
using IsraeliSuperMarketManager;
using IsraeliSuperMarketModels;

namespace IsraeliSuperMarketWinFormsApp
{
    public partial class LogInForm : Form
    {
        private readonly SuperMarketManager _manager;

        public LogInForm()
        {
            InitializeComponent();
            _manager = new SuperMarketManager();
        }

        private async void logInButton_Click(object sender, EventArgs e)
        {
            if (userNameTextBox.Text.Equals(string.Empty))
            {
                MessageBox.Show(@"נא להזין שם משתמש");
                return;
            }
            if (passwordTextBox.Text.Equals(string.Empty))
            {
                MessageBox.Show(@"נא להזין סיסמה");
                return;
            }
            var user = new User
            {
                UserName = userNameTextBox.Text,
                Password = passwordTextBox.Text
            };
            try
            {
                var logInReasult = await _manager.LogInAsync(user);
                if (logInReasult.Item2)
                {
                    var mainForm = new MainForm(this, logInReasult.Item1);
                    Hide();
                    mainForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show(logInReasult.Item3);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"  שגיאה בהתחברות לשרת");
            }
        }
    }
}
