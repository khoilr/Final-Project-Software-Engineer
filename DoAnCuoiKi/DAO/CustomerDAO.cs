using DoAnCuoiKi.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi.DAO
{
    public class CustomerDAO
    {
        private static CustomerDAO instance;
        public static CustomerDAO Instance
        {
            get { if (instance == null) instance = new CustomerDAO(); return instance; }
            private set { instance = value; }
        }
        private CustomerDAO() { }

        public CustomerDTO getCustomerById(String id)
        {
            String query = @"select * from customers where customer_id = @id";
            Dictionary<String, String> parameters = new Dictionary<string, string>() { { "@id", id } };

            DataTable data = DataProviderDAO.Instance.ExecuteQuery(query, parameters);

            return data.Rows.Count != 0 ? new CustomerDTO(data.Rows[0]) : null;
        }

        public List<CustomerDTO> getCustomers()
        {
            List<CustomerDTO> list = new List<CustomerDTO>();

            String query = "select * from customers";
            DataTable data = DataProviderDAO.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
                list.Add(new CustomerDTO(row));

            return list;
        }

        public bool addCustomer(CustomerDTO customer)
        {
            String name = customer.Name;
            String address = customer.Address;
            String phone = customer.Phone;

            String query = @"insert into customers (full_name, address, phone)
                            values (@name, @address, @phone)";
            Dictionary<String, String> parameters = new Dictionary<string, string>()
                                                    { { "@name", name },
                                                    { "@address", address },
                                                    { "@phone", phone } };

            bool execute = DataProviderDAO.Instance.ExecuteNoneQuery(query, parameters);
            return execute;
        }
    }
}
