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
        Bank bank;

        public BankManager(int id, string name)
        {
            this.bank = new Bank(id, name);
        }


        public List<string> GetTransactionHistory(string userName)
        {
            return bank.transactionHistory[userName];
        }

        public bool Login(string userName, string password)
        {
            return bank.users[userName].password == password;
        }

        public void AddTransaction(string userName, string transaction)
        {
            bank.transactionHistory[userName].Add(transaction);

        }

        public void UpdateBalance(string userName, double amount)
        {
            bank.users[userName].balance += amount;
        }

        public void AddAccount(string userName, string password)
        {
            bank.users.Add(userName, new BankAccount(userName, password));
            bank.transactionHistory.Add(userName, new List<string>());
        }

        public bool UserExists(string userName)
        {
            return bank.users.ContainsKey(userName);
        }

        public double GetBalance(string userName)
        {
            return bank.users[userName].balance;
        }


    }
}
