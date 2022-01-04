using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi.DTO
{
    public class CustomerDTO
    {
        String id;
        String name;
        String address;
        String phone;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }

        public CustomerDTO(string id, string name, string address, string phone)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
        }

        public CustomerDTO(String name, String address, String phone)
        {
            Name = name;
            Address = address;
            Phone = phone;
        }

        public CustomerDTO(DataRow row)
        {
            Id = row["customer_id"].ToString();
            Name = row["full_name"].ToString();
            Address = row["address"].ToString();
            Phone = row["phone"].ToString();
        }
    }
}
