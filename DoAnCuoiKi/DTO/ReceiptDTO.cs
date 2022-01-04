using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCuoiKi.DTO
{
    public class ReceiptDTO
    {
        private String receiptId;
        private String to;
        private String by;
        private String date;
        private String shipmentStatus;
        private String paymentStatus;
        private String operation;
        private String byId;
        private String toId;
        private String paymentMethod;

        public ReceiptDTO(String operation, String by, String date, String receiptId, String to, String shipmentStatus, String paymentStatus)
        {
            this.receiptId = receiptId;
            this.operation = operation;
            this.by = by;
            this.date = date;
            this.To = to;
            this.ShipmentStatus = shipmentStatus;
            this.PaymentStatus = paymentStatus;
        }

        public ReceiptDTO(String byId, String date)
        {
            ById = byId;
            Date = date;
        }

        public ReceiptDTO() { }

        public ReceiptDTO(String byId, String toId, String date, String shipmentStatus, String paymentStatus, string paymentMethod)
        {
            ById = byId;
            ToId = toId;
            Date = date;
            ShipmentStatus = shipmentStatus;
            PaymentStatus = paymentStatus;
            PaymentMethod = paymentMethod;
        }

        public ReceiptDTO(DataRow row)
        {
            receiptId = row["id"].ToString();
            operation = row["status"].ToString();
            by = row["by"].ToString();
            date = row["date_created"].ToString();
            to = row["to"].ToString();
            shipmentStatus = row["shipment_status"].ToString();

            switch (row["payment_status"].ToString())
            {
                case "True":
                    paymentStatus = "Paid";
                    break;

                case "False":
                    paymentStatus = "Not pay yet";
                    break;

                default:
                    paymentStatus = "";
                    break;
            }

            //paymentStatus = row["payment_status"].ToString();
        }

        public string Operation { get => operation; set => operation = value; }
        public string By { get => by; set => by = value; }
        public string Date { get => date; set => date = value; }
        public string ReceiptId { get => receiptId; set => receiptId = value; }
        public string To { get => to; set => to = value; }
        public string ShipmentStatus { get => shipmentStatus; set => shipmentStatus = value; }
        public string PaymentStatus { get => paymentStatus; set => paymentStatus = value; }
        public string ById { get => byId; set => byId = value; }
        public string ToId { get => toId; set => toId = value; }
        public string PaymentMethod { get => paymentMethod; set => paymentMethod = value; }
    }
}
