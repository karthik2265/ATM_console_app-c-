using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Models
{
    public class Transaction
    {
        public string SenderAccountId;
        public string RecieverAccountId;
        public string BankId;
        public string Id;
        public double Amount;
        public DateTime On;
        public TransactionType Type;

        public Transaction(string SenderAccountId, string RecieverAccountId, double Amount, DateTime On, TransactionType Type) 
        {
            this.SenderAccountId = SenderAccountId;
            this.RecieverAccountId = RecieverAccountId;
            this.Amount = Amount;
            this.On = On;
            this.Type = Type;
            this.Id = getTransactionId(SenderAccountId, BankId, On);
        }

        private string getTransactionId(string SenderAccountId, string BankId, DateTime On)
        {
            string date = On.ToString();
            string Id = "TXN" + BankId + SenderAccountId + date;
            return Id;
        }


    }
}
