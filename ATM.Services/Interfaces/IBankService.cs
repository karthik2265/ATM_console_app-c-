using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Models;

namespace ATM.Services.Interfaces
{
    public interface IBankService
    {
        public bool StaffLogin(string name, string password);

        public bool StaffExists(string name);

        public List<Transaction> GetTransactionHistory(Customer customer);

        public bool Login(string customerName, string password);

        public void AddTransaction(Customer sender, Customer reciever, double amount, TransactionType transactionType);

        public bool DepositAmount(Customer customer, double amount);

        public bool WithdrawAmount(Customer customer, double amount);

        public bool TransferAmount(Customer sender, Customer reciever, double amount);

        public void AddAccount(string customerName, string password);

        public bool CustomerExists(string customerName);

        public double GetBalance(Customer customer);

        public Customer GetCustomer(string customerName);

        public Staff GetStaff(string name);
    }
}
