using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Models
{
    public class Customer
    {
        // to set account number
        public static int x = 2021;

        public string UserName;
        public string Password;
        public double Balance;
        public string AccountNo;
        public List<string> TransactionHistory;

        public Customer(string password)
        {
            Password = password;
        } 

        public Customer(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
            this.Balance = 0;
            this.TransactionHistory = new List<string>();
            this.AccountNo = Convert.ToString(++x);
        }
    }
}
