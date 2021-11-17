using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATM.Models;
using ATM.Services.Interfaces;

namespace ATM.Services
{
    public class BankService 
    {
        public Bank AlphaBank;

        public BankService(Bank b)
        {
            this.AlphaBank = b;
        }

        public BankService(string id, string name)
        {
            this.AlphaBank = new Bank(id, name, Currency.INR);
        }

        public bool StaffLogin(string name, string password)
        {
            return AlphaBank.Staff[name].Password == password;
        }

        public bool StaffExists(string name)
        {
            return AlphaBank.Staff.ContainsKey(name);
        }


        public List<Transaction> GetTransactionHistory(Customer customer)
        {
            return customer.Transactions;
        }

        public Customer Login(string customerName, string password, SQLService sqlService)
        {
            return sqlService.CustomerLogIn(customerName, password);
        }

        public void AddTransaction(Customer sender, Customer reciever, double amount, TransactionType transactionType)
        {
            DateTime date = DateTime.Now;
            Transaction transaction = new Transaction(sender.Name, reciever.Name, amount, date, transactionType);
            AlphaBank.Transactions.Add(transaction.Id ,transaction);
            sender.Transactions.Add(transaction);
        }

        public bool DepositAmount(Customer customer, double amount)
        {
            customer.Balance += amount;
            return true;
        }

        public bool WithdrawAmount(Customer customer, double amount)
        {
            customer.Balance -= amount;
            return true;
        }

        public bool TransferAmount(Customer sender, Customer reciever, double amount)
        {
            sender.Balance -= amount;
            reciever.Balance += amount;
            return true;
        }


        public void AddAccount(string customerName, string password, SQLService sqlService)
        {
            Customer newCustomer = new(customerName, password, AlphaBank.Id);
            sqlService.AddCustomer(newCustomer);

        }

        

        public double GetBalance(Customer customer)
        {
            return customer.Balance;
        }

        public Customer GetCustomer(string customerName,  SQLService sqlService)
        {
            if (AlphaBank.Customers.ContainsKey(customerName)) return AlphaBank.Customers[customerName];
            else return null;
        }

        public Staff GetStaff(string name)
        {
            if (AlphaBank.Staff.ContainsKey(name)) return AlphaBank.Staff[name];
            else return null;
        }


    }
}
