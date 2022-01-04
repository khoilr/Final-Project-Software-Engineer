using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi.DTO
{
    public class AccountDTO
    {
        private String id;
        private String name;
        private String user;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string User { get => user; set => user = value; }

        public AccountDTO(String id, String name, String user)
        {
            Id = id;
            Name = name;
            User = user;
        }

        public AccountDTO(DataRow row)
        {
            Id = row["account_id"].ToString();
            Name = row["full_name"].ToString();
            User = row["username"].ToString();
        }
    }
}
