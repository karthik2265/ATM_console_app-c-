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
        Bank AlphaBank;

        public BankManager(int id, string name)
        {
            this.AlphaBank = new Bank(id, name);
        }


        public List<string> GetTransactionHistory(string customerName)
        {
            return AlphaBank.Customers[customerName].TransactionHistory;
        }

        public bool Login(string customerName, string password)
        {
            return AlphaBank.Customers[customerName].Password == password;
        }

        public void AddTransaction(string customerName, string transaction)
        {
            AlphaBank.Customers[customerName].TransactionHistory.Add(transaction);

        }

        public bool DepositAmount(string customerName, double amount)
        {
            AlphaBank.Customers[customerName].Balance += amount;
            return true;
        }

        public bool WithdrawAmount(string customerName, double amount)
        {
            AlphaBank.Customers[customerName].Balance -= amount;
            return true;
        }

        public bool TransferAmount(string senderName, double amount, string reciverName)
        {
            AlphaBank.Customers[senderName].Balance -= amount;
            if (AlphaBank.Customers.ContainsKey(reciverName))
            {
                DepositAmount(reciverName, amount);
                AddTransaction(senderName, "recieved " + amount + " from " + senderName);

            }
            return true;
        }


        public void AddAccount(string customerName, string password)
        {
            AlphaBank.Customers.Add(customerName, new Customer(customerName, password));
        }

        public bool CustomerExists(string customerName)
        {
            return AlphaBank.Customers.ContainsKey(customerName);
        }

        public double GetBalance(string customerName)
        {
            return AlphaBank.Customers[customerName].Balance;
        }


    }
}
