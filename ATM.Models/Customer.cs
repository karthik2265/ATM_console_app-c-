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
        private static int x = 2021;

        // to set accountId 
        private DateTime currentDate;


        public string AccountId;
        public string Name;
        public string Password;
        public double Balance;
        public string AccountNo;
        public List<string> TransactionHistory;
 

        public Customer(string userName, string password)
        {
            this.Name = userName;
            this.Password = password;
            this.Balance = 0;
            this.TransactionHistory = new List<string>();
            this.AccountNo = Convert.ToString(++x);
            currentDate = DateTime.Now;
            string date = currentDate.ToShortDateString();
            // set accountId
            AccountId = "";
            for (int i=0; i<3; i++)  AccountId += this.Name;
            AccountId += date;
        }
    }
}
