using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi.DTO
{
    public class DetailDTO : ReceiptDTO
    {
        private String productId;
        private string detailId;
        private string name;
        private int quantity;
        private double price;
        private double total;

        public string DetailId { get => detailId; set => detailId = value; }
        public string Name { get => name; set => name = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double Price { get => price; set => price = value; }
        public double Total { get => total; set => total = value; }
        public String ProductId { get => productId; set => productId = value; }

        public DetailDTO(string productId, string name, int quantity, double price, double total)
        {
            ProductId = productId;
            Name = name;
            Quantity = quantity;
            Price = price;
            Total = total;
        }

        public DetailDTO(String receiptId, String productId, int quantity, double price)
        {
            ReceiptId = receiptId;
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }

        public DetailDTO(DataRow row)
        {
            ProductId = row["product_id"].ToString();
            Name = row["name"].ToString();
            Quantity = Convert.ToInt32(row["quantity"]);
            Price = Convert.ToDouble(row["price"]);
            Total = Convert.ToDouble(row["total"]);
        }
    }
}
