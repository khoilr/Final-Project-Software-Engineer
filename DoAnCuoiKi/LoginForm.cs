using DoAnCuoiKi.DAO;
using DoAnCuoiKi.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCuoiKi
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_click(object sender, EventArgs e)
        {
            // retrieve data from boxes
            String user = userBox.Text;
            String password = passBox.Text;

            // VERIFY USER
            if (AccountDAO.Instance.login(user, password))
            {
                // verified
                AccountDTO acc = AccountDAO.Instance.getAccountByUser(user);
                Hide();
                WarehouseManagementForm f = new WarehouseManagementForm(acc);
                f.ShowDialog();
            }
            else MessageBox.Show("Username or password is incorrect", "Cannot verify", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
