using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi.DTO
{
    public class ProductDTO
    {
        private String id;
        private String name;
        private int inventory;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Inventory { get => inventory; set => inventory = value; }

        public ProductDTO(String id, String name, int inventory)
        {
            Id = id;
            Name = name;
            Inventory = inventory;
        }

        public ProductDTO(String name, int inventory)
        {
            Name = name;
            Inventory = inventory;
        }

        public ProductDTO(DataRow row)
        {
            Id = row["product_id"].ToString();
            Name = row["name"].ToString();
            Inventory = Convert.ToInt32(row["inventory"]);
        }
    }
}
