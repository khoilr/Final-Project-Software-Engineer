using DoAnCuoiKi.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi.DAO
{
    public class DetailDAO
    {
        private static DetailDAO instance;

        public static DetailDAO Instance
        {
            get { if (instance == null) instance = new DetailDAO(); return instance; }
            set => instance = value;
        }
        private DetailDAO() { }

        public List<DetailDTO> GetImportDetail(String receiptId)
        {
            List<DetailDTO> detail = new List<DetailDTO>();

            String query = @"select temp.*, [dbo].[import_details].price, [dbo].[import_details].quantity, [dbo].[import_details].price * [dbo].[import_details].quantity as 'total'
                            from [dbo].[import_details]
                            inner join
                            (select product_id, name
                            from [dbo].[products]) temp
                            on temp.product_id = [dbo].[import_details].product_id
                            where [dbo].[import_details].import_receipt_id = @receiptID;";
            Dictionary<String, String> parameters = new Dictionary<String, String>()
                                                    { { "@receiptID", receiptId } };
            DataTable data = DataProviderDAO.Instance.ExecuteQuery(query, parameters);

            foreach (DataRow row in data.Rows)
                detail.Add(new DetailDTO(row));

            return detail;
        }

        public List<DetailDTO> GetDeliveryDetail(String receiptId)
        {
            List<DetailDTO> detail = new List<DetailDTO>();

            String query = @"select temp.*,
                            [dbo].[delivery_details].price,
                            [dbo].[delivery_details].quantity,
                            [dbo].[delivery_details].price * [dbo].[delivery_details].quantity as 'total'
                            from [dbo].[delivery_details]
                            inner join
                            (select product_id, name
                            from [dbo].[products]) temp
                            on temp.product_id = [dbo].[delivery_details].product_id
                            where [dbo].[delivery_details].delivery_receipt_id = @receiptID;";
            Dictionary<String, String> parameters = new Dictionary<String, String>()
                                                    { { "@receiptID", receiptId } };
            DataTable data = DataProviderDAO.Instance.ExecuteQuery(query, parameters);

            foreach (DataRow row in data.Rows)
                detail.Add(new DetailDTO(row));

            return detail;
        }

        public bool insertImportDetail(DetailDTO detail)
        {
            String receiptId = detail.ReceiptId;
            String productId = detail.ProductId;
            String quantity = detail.Quantity.ToString();
            String price = detail.Price.ToString();

            String query = @"insert into import_details (import_receipt_id, product_id, quantity, price)
                            values (@id, @productId, @quantity, @price)";
            Dictionary<String, String> parameters = new Dictionary<string, string>
                                                    { {"@id", receiptId},
                                                    {"@productId", productId},
                                                    {"@quantity", quantity },
                                                    {"@price", price }};

            bool execute = DataProviderDAO.Instance.ExecuteNoneQuery(query, parameters);
            return execute;
        }

        public bool insertDeliveryDetail(DetailDTO detail)
        {
            String receiptId = detail.ReceiptId;
            String productId = detail.ProductId;
            String quantity = detail.Quantity.ToString();
            String price = detail.Price.ToString();

            String query = @"insert into delivery_details (delivery_receipt_id, product_id, quantity, price) 
                            values (@receipt_id, @product_id, @quantity, @price)";

            Dictionary<String, String> parameters = new Dictionary<string, string>();
            parameters.Add("@receipt_id", receiptId);
            parameters.Add("@product_id", productId);
            parameters.Add("@quantity", quantity);
            parameters.Add("@price", price);

            bool execute = DataProviderDAO.Instance.ExecuteNoneQuery(query, parameters);
            return execute;
        }
    }
}
