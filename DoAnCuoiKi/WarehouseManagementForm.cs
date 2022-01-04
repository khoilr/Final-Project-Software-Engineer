using DoAnCuoiKi.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnCuoiKi.DTO;

namespace DoAnCuoiKi
{
    public partial class WarehouseManagementForm : Form
    {
        public AccountDTO account;
        public WarehouseManagementForm(AccountDTO account)
        {
            InitializeComponent();

            this.account = account;
            greetingLabel.Text = "Hello, " + account.Name;

            loadReceipts();
            loadCustomers();
        }
        #region statistic
        private void loadReceipts()
        {
            receiptsListView.Items.Clear();

            List<ReceiptDTO> data = ReceiptDAO.Instance.GetReceipts();

            foreach (ReceiptDTO row in data)
            {
                String name = row.By;
                String date = Convert.ToDateTime(row.Date).ToString("dd/MM/yyyy");
                String operation = row.Operation;
                String receiptId = row.ReceiptId;
                String to = row.To;
                String shipment = row.ShipmentStatus;
                String payment = row.PaymentStatus;

                String[] listViewRow = { operation, name, to, date, shipment, payment };
                ListViewItem item = new ListViewItem(listViewRow);
                item.Tag = receiptId;

                receiptsListView.Items.Add(item);
            }
        }
        private void showDetail(String id, String operation)
        {
            List<DetailDTO> list = new List<DetailDTO>();

            switch (operation)
            {
                case "Import":
                    list = DetailDAO.Instance.GetImportDetail(id);
                    break;
                case "Delivery":
                    list = DetailDAO.Instance.GetDeliveryDetail(id);
                    break;
            }

            foreach (DetailDTO detail in list)
            {
                String name = detail.Name;
                String quantiy = Convert.ToString(detail.Quantity);
                String price = Convert.ToString(detail.Price);
                String total = Convert.ToString(detail.Total);

                String[] listViewRow = { name, quantiy, price, total };
                ListViewItem item = new ListViewItem(listViewRow);

                detailListView.Items.Add(item);
            }

        }

        private String current_id;

        private void receiptsListView_MouseClick(object sender, MouseEventArgs e)
        {
            editReceiptButton.Enabled = false;
            detailListView.Items.Clear();

            for (int i = 0; i < receiptsListView.Items.Count; i++)
            {
                var rectangle = receiptsListView.GetItemRect(i);
                if (rectangle.Contains(e.Location))
                {
                    ListViewItem item = receiptsListView.Items[i];
                    String id = item.Tag.ToString();
                    String operation = item.Text;

                    if (operation == "Delivery")
                        editReceiptButton.Enabled = true;

                    current_id = id;

                    showDetail(id, operation);
                    return;
                }
            }
        }

        private void editReceiptButton_Click(object sender, EventArgs e)
        {
            EditDeliveryReceiptForm deli = new EditDeliveryReceiptForm(current_id);
            deli.Show();
        }

        private void logout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm f = new LoginForm();
            f.ShowDialog();
        }
        #endregion

        #region import
        /********
         * IMPORT
        ********/
        private void importAddButton_Click(object sender, EventArgs e)
        {
            // get data from input box
            String name = importNameBox.Text;
            float fQuantity = (float)importQuantityBox.Value;
            float fPrice = (float)importPriceBox.Value;

            // don't add to ListView if 
            if (!(String.IsNullOrEmpty(name) || fQuantity <= 0 || fPrice <= 0))
            {
                String quantity = Convert.ToString(fQuantity);
                String price = Convert.ToString(fPrice);

                // add item to ListView
                String[] data = { name, quantity, price };
                ListViewItem row = new ListViewItem(data);
                importListView.Items.Add(row);

                // clear input boxes
                importNameBox.Text = String.Empty;
                importQuantityBox.Value = 0;
                importPriceBox.Value = 0;
            }
            else
                MessageBox.Show("Input information should not be empty",
                                "Empty box",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

        }

        private void clearImportButton_Click(object sender, EventArgs e)
        {
            importListView.Items.Clear();
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            DateTime date = importDatePicker.Value;
            String accountId = account.Id;

            //insert to import_receipts
            ReceiptDTO receipt = new ReceiptDTO(accountId, date.ToString());

            // insert to import_details
            if (ReceiptDAO.Instance.insertImportReceipt(receipt))
            {
                String receiptId = ReceiptDAO.Instance.getLastestId(true);
                foreach (ListViewItem item in importListView.Items)
                {
                    String name = item.Text;
                    int quantity = Convert.ToInt32(item.SubItems[1].Text);
                    double price = Convert.ToDouble(item.SubItems[2].Text);

                    _ = !ProductDAO.Instance.isProductExist(name) ? ProductDAO.Instance.insertProduct(new ProductDTO(name, quantity)) :
                                                                    ProductDAO.Instance.updateInventory(name, quantity, true);

                    ProductDTO product = ProductDAO.Instance.getProductByName(name);
                    String productId = product.Id;

                    DetailDTO detail = new DetailDTO(receiptId, productId, quantity, price);
                    DetailDAO.Instance.insertImportDetail(detail);
                }
                MessageBox.Show("Added to database successfully", "Adding status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                importListView.Items.Clear();
            }

            loadReceipts();
        }
        #endregion

        #region export
        /********
         * EXPORT
        ********/

        List<CustomerDTO> customers = new List<CustomerDTO>();
        CustomerDTO current_customer = null;
        private void loadCustomers()
        {
            customers = CustomerDAO.Instance.getCustomers();

            foreach (CustomerDTO customer in customers)
                customerComboBox.Items.Add(customer.Name);
        }

        private void exportAddButton_Click(object sender, EventArgs e)
        {
            // get data from input box
            String name = exportNameBox.Text;
            float fQuantity = (float)exportQuantityBox.Value;
            float fPrice = (float)exportPriceBox.Value;

            if (!ProductDAO.Instance.isProductExist(name) || ProductDAO.Instance.getProductByName(name).Inventory < fQuantity)
            {
                MessageBox.Show("Not enough products in stock", "Not enough", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            // don't add to ListView if 
            if (!(String.IsNullOrEmpty(name) || fQuantity <= 0 || fPrice <= 0))
            {
                String quantity = Convert.ToString(fQuantity);
                String price = Convert.ToString(fPrice);

                // add item to ListView
                String[] data = { name, quantity, price };
                ListViewItem row = new ListViewItem(data);
                exportListView.Items.Add(row);

                // clear input boxes
                exportNameBox.Text = String.Empty;
                exportQuantityBox.Value = 0;
                exportPriceBox.Value = 0;
            }
            else
                MessageBox.Show("Input information should not be empty",
                                "Empty box",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
        }

        private void clearExportButton_Click(object sender, EventArgs e)
        {
            exportListView.Items.Clear();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if (customerComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a customer", "No customer selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (shipComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a shipment status", "No shipment status selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (paymentStatusBox.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a payment method", "No payment method selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (payComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a payment status", "No payment status selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            String date = exportDatePicker.Value.ToString();
            String accountId = account.Id;
            String customerId = current_customer.Id;
            String ship = shipComboBox.SelectedItem.ToString();
            String pay = payComboBox.SelectedItem.ToString() == "Paid" ? 1.ToString() : 0.ToString();
            String paymentMethod = paymentStatusBox.SelectedItem.ToString().ToLower();

            ReceiptDTO receipt = new ReceiptDTO(accountId, customerId, date, ship, pay, paymentMethod);

            if (ReceiptDAO.Instance.insertDeliveryReceipt(receipt)) // insert to delivery_receipts
            {
                String receiptId = ReceiptDAO.Instance.getLastestId(false);
                foreach (ListViewItem item in exportListView.Items)
                {
                    String name = item.Text;
                    String productId = ProductDAO.Instance.getProductByName(name).Id;
                    int quantity = Convert.ToInt32(item.SubItems[1].Text);
                    double price = Convert.ToDouble(item.SubItems[2].Text);

                    ProductDAO.Instance.updateInventory(name, quantity, false);

                    DetailDTO detail = new DetailDTO(receiptId, productId, quantity, price);
                    DetailDAO.Instance.insertDeliveryDetail(detail);
                }
                MessageBox.Show("Added to database successfully", "Adding status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                exportListView.Items.Clear();
            }

            loadReceipts();
        }

        private void customerComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            String name = customerComboBox.SelectedItem.ToString();
            current_customer = customers.Find(x => x.Name == name);

            String address = current_customer.Address;
            String phone = current_customer.Phone;

            customerAddressBox.Text = address;
            customerPhoneBox.Text = phone;
        }

        #endregion
    }
}
