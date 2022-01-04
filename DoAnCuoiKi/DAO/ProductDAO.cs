using DoAnCuoiKi.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi.DAO
{
    public class ProductDAO
    {
        private static ProductDAO instance;

        public static ProductDAO Instance
        {
            get { if (instance == null) instance = new ProductDAO(); return instance; }
            private set => instance = value;
        }

        private ProductDAO() { }

        public ProductDTO getProductByName(String name)
        {
            String query = "select * from products where name = @name";
            Dictionary<String, String> parameters = new Dictionary<string, string>() { { "@name", name } };

            // name is unique so it suppose to return only 1 row
            DataTable data = DataProviderDAO.Instance.ExecuteQuery(query, parameters);
            return data.Rows.Count == 0 ? null : new ProductDTO(data.Rows[0]);
        }

        public bool isProductExist(String name)
        {
            return getProductByName(name) != null;
        }

        public bool insertProduct(ProductDTO product)
        {
            String name = product.Name;
            String inventory = product.Inventory.ToString();

            String query = @"insert into products (name, inventory)
                values (@name, @inventory)";
            Dictionary<String, String> parameters = new Dictionary<String, String>()
                                                        { { "@name", name },
                                                        { "@inventory", inventory } };

            bool execute = DataProviderDAO.Instance.ExecuteNoneQuery(query, parameters);
            return execute;
        }

        public bool updateInventory(String name, int quantity, bool adding)
        {
            String query = adding ? @"update products set inventory = inventory + @quantity where name = @name" :
                                    @"update products set inventory = inventory - @quantity where name = @name";
            Dictionary<String, String> parameters = new Dictionary<string, string>()
                                                    { { "@name", name},
                                                    { "@quantity", quantity.ToString() } };

            bool execute = DataProviderDAO.Instance.ExecuteNoneQuery(query, parameters);
            return execute;
        }

        public List<ProductDTO> GetProducts()
        {
            List<ProductDTO> products = new List<ProductDTO>();
            String query = "select * from products";

            DataTable data = DataProviderDAO.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
                products.Add(new ProductDTO(row));

            return products;
        }
    }
}
