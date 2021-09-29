using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Models
{
    public class BankAccount
    {
        public string userName;
        public string password;
        public int balance;

        public BankAccount(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
            this.balance = 0;
        }
    }
}
