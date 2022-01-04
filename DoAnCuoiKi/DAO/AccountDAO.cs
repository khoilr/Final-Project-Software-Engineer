using DoAnCuoiKi.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace DoAnCuoiKi.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            set => instance = value;
        }

        private AccountDAO() { }

        // verify account
        public bool login(String user, String password)
        {
            // query account from database
            String query = "select * from accounts where username = @username";
            Dictionary<String, String> parameters = new Dictionary<String, String>() { { "@username", user } };
            DataTable data = DataProviderDAO.Instance.ExecuteQuery(query, parameters);

            // account exist
            if (data.Rows.Count > 0)
            {
                // get password from database
                String verify = Convert.ToString(data.Rows[0]["Password"]);

                // password is correct
                if (BC.Verify(password, verify)) return true;
            }

            // neither account doesn't exist nor password is incorrect
            return false;
        }

        // get account information
        public AccountDTO getAccountByUser(String user)
        {
            // query account from database
            String query = "select account_id, full_name, username from accounts where username = @user";
            Dictionary<String, String> parameters = new Dictionary<string, string>() { { "@user", user } };
            DataTable data = DataProviderDAO.Instance.ExecuteQuery(query, parameters);

            // return account if exist, otherwise null
            return data.Rows.Count > 0 ? new AccountDTO(data.Rows[0]) : null;

        }
    }
}
