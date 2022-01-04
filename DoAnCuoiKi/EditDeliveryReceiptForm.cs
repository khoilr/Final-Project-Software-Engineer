using DoAnCuoiKi.DAO;
using DoAnCuoiKi.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCuoiKi
{
    public partial class EditDeliveryReceiptForm : Form
    {

        private String id;
        public EditDeliveryReceiptForm(String id)
        {
            InitializeComponent();

            this.id = id;

            loadReceipt(id);
        }

        private void loadReceipt(String id)
        {
            ReceiptDTO receipt = ReceiptDAO.Instance.getDeliveryReceipt(id);

            idBox.Text = receipt.ReceiptId;
            byBox.Text = receipt.By;
            toBox.Text = receipt.To;
            datePicker.Value = Convert.ToDateTime(receipt.Date);
            shipBox.SelectedIndex = receipt.ShipmentStatus == "ship ping" ? 0 : 1;
            payBox.SelectedIndex = receipt.PaymentStatus == "Paid" ? 0 : 1;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            String ship = shipBox.SelectedItem.ToString().ToLower();
            String pay = payBox.SelectedItem.ToString() == "Paid" ? 1.ToString() : 0.ToString();

            bool a = ReceiptDAO.Instance.updatePaymentStatus(id, pay);
            bool b = ReceiptDAO.Instance.updateShipmentStatus(id, ship);

            bool c = a && b;

            if (c) { MessageBox.Show("Update successfully", "Update status", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); Hide(); }
            else MessageBox.Show("Update unsuccessfully", "Update status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
