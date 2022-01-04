using DoAnCuoiKi.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCuoiKi.DAO
{
    public class ReceiptDAO
    {
        private static ReceiptDAO instance;

        public static ReceiptDAO Instance
        {
            get { if (instance == null) instance = new ReceiptDAO(); return instance; }
            set => instance = value;
        }
        private ReceiptDAO() { }

        public List<ReceiptDTO> GetReceipts()
        {
            List<ReceiptDTO> receipts = new List<ReceiptDTO>();

            String query = @"select temp.id, temp.[to], temp.shipment_status, temp.payment_status, accounts.full_name as 'by', temp.date_created, temp.status from [dbo].[accounts]
                            inner join
                            (select full_name as 'to', id, shipment_status, payment_status, account_id, date_created, status
                            from customers
                            right join
                            (select import_receipt_id id, null as customer_id, null as shipment_status, null as payment_status, account_id, date_created, 'Import' as status from [dbo].[import_receipts]
                            union
                            select delivery_receipt_id id, customer_id, shipment_status, payment_status, account_id, date_created, 'Delivery' as status from [dbo].[delivery_receipts]) a
                            on a.customer_id = customers.customer_id) temp
                            on temp.account_id = [dbo].[accounts].account_id
                            order by date_created desc, id;";
            DataTable data = DataProviderDAO.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
                receipts.Add(new ReceiptDTO(row));

            return receipts;
        }
        public ReceiptDTO getDeliveryReceipt(String id)
        {
            String query = @"select delivery_receipt_id id, date_created, shipment_status, payment_status, a.full_name 'by', b.full_name 'to', 'Delivery' as status from [dbo].[delivery_receipts]
                            inner join
                            (select account_id, full_name from [dbo].[accounts]) a
                            on a.account_id = [dbo].[delivery_receipts].account_id
                            inner join
                            (select customer_id, full_name from [dbo].[customers]) b
                            on b.customer_id = [dbo].[delivery_receipts].customer_id
                            where delivery_receipt_id = @id";
            Dictionary<String, String> parameters = new Dictionary<string, string>() { { "@id", id } };

            DataTable data = DataProviderDAO.Instance.ExecuteQuery(query, parameters);
            ReceiptDTO receipt = new ReceiptDTO(data.Rows[0]);

            return receipt;
        }

        public bool updateShipmentStatus(String id, String status)
        {
            String query = @"update delivery_receipts 
                            set shipment_status = @status
                            where delivery_receipt_id = @id";
            Dictionary<String, String> parameters = new Dictionary<string, string>() { { "@id", id }, { "@status", status } };

            bool execute = DataProviderDAO.Instance.ExecuteNoneQuery(query, parameters);
            return execute;
        }

        public bool updatePaymentStatus(String id, String status)
        {
            String query = @"update delivery_receipts 
                            set payment_status = @status
                            where delivery_receipt_id = @id";
            Dictionary<String, String> parameters = new Dictionary<string, string>() { { "@id", id }, { "@status", status } };

            bool execute = DataProviderDAO.Instance.ExecuteNoneQuery(query, parameters);
            return execute;
        }

        public String getLastestId(bool import)
        {
            String query = import ? "select max(import_receipt_id) from [dbo].[import_receipts]" :
                                    "select max(delivery_receipt_id) from [dbo].[delivery_receipts]";
            String data = DataProviderDAO.Instance.ExecuteScalar(query).ToString();

            return data;
        }
        public bool insertImportReceipt(ReceiptDTO receipt)
        {
            String id = receipt.ById;
            String date = receipt.Date;

            String query = @"insert into import_receipts (account_id, date_created) 
                            values (@id, @date)";
            Dictionary<String, String> parameters = new Dictionary<String, String>() { { "@id", id }, { "@date", date } };
            bool execute = DataProviderDAO.Instance.ExecuteNoneQuery(query, parameters);

            return execute;
        }

        public bool insertDeliveryReceipt(ReceiptDTO receipt)
        {
            String byId = receipt.ById;
            String toId = receipt.ToId;
            String date = receipt.Date;
            String shipmentStatus = receipt.ShipmentStatus;
            String paymentStatus = receipt.PaymentStatus;
            String paymentMethod = receipt.PaymentMethod;

            string query = @"insert into delivery_receipts (account_id, customer_id, date_created, shipment_status, payment_status, payment_method)
                            values (@by, @to, @date, @ship, @pay, @paymentMethod)";

            Dictionary<String, String> parameters = new Dictionary<string, string>();
            parameters.Add("@by", byId);
            parameters.Add("@to", toId);
            parameters.Add("@date", date);
            parameters.Add("@ship", shipmentStatus);
            parameters.Add("@pay", paymentStatus);
            parameters.Add("@paymentMethod", paymentMethod);

            bool execute = DataProviderDAO.Instance.ExecuteNoneQuery(query, parameters);
            return execute;
        }
    }
}
