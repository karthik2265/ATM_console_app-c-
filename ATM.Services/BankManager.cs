using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Models;

namespace ATM.Services
{
    public class BankManager
    {
        int managingBankId;
        Bank bank;

        public BankManager(Bank b)
        {
            this.managingBankId = b.id;
            this.bank = b;
        }

        public List<string> GetTransactionHistory(string userName)
        {
            return bank.transactionHistory[userName];
        }

        public bool Login(string userName, string password)
        {
            return bank.users[userName] == password;
        }

        public void AddTransaction(string userName, string transaction)
        {
            bank.transactionHistory[userName].Add(transaction);

        }

        public void AddAccount(string userName, string password)
        {
            bank.users.Add(userName, password);
            bank.transactionHistory.Add(userName, new List<string>());
        }

        public bool UserExists(string userName)
        {
            return bank.users.ContainsKey(userName);
        }

        public bool CheckPassword(string userName, string password)
        {
            return bank.users[userName] == password;
        }

    }
}
