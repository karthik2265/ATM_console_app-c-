using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Models.enums;

namespace ATM.Models
{
    public class Customer
    {

        // to set accountId 
        private DateTime currentDate;


        public string Id;
        public string Name;
        public string Password;
        public double Balance;
        public List<Transaction> Transactions;
        public string BankId;
        public AccountStatus Status;  

        public Customer(string userName, string password, string bankId, AccountStatus status = AccountStatus.Active)
        {
            this.Name = userName;
            this.Password = password;
            this.Balance = 0;
            this.Transactions = new List<Transaction>();
            currentDate = DateTime.Now;
            string date = currentDate.ToShortDateString();
            // set accountId
            Id = "";
            for (int i=0; i<3; i++)  Id += this.Name[i];
            Id += date;
            // status
            this.Status = status;
            this.BankId = bankId;
        }

        public Customer(string id, string name, string password, double balance, AccountStatus status, string bankId) : this(name, password, bankId, status)
        {
            this.Id = id;
            this.Balance = balance;
        }
    }
}
