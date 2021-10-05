using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Models
{
    public class Bank
    {
        public Dictionary<string, List<string>> transactionHistory;
        public Dictionary<string, BankAccount> users;
        public string name;
        public int id;

        public Bank(int id, string name)
        {
            this.id = id;
            this.name = name;
            transactionHistory = new Dictionary<string, List<string>>();
            users = new Dictionary<string, BankAccount>();
        }
    }
}
