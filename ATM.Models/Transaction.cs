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
        public string SenderBankId;
        public string RecieverBankId;
        public string Id;
        public double Amount;
        public DateTime Date;
        public TransactionType Type;

        public Transaction(string SenderAccountId, string RecieverAccountId, string SenderBankId, string RecieverBankId, double Amount, DateTime On, TransactionType Type) 
        {
            this.SenderAccountId = SenderAccountId;
            this.RecieverAccountId = RecieverAccountId;
            this.SenderBankId = SenderBankId;
            this.RecieverBankId = RecieverBankId;
            this.Amount = Amount;
            this.Date = On;
            this.Type = Type;
            this.Id = getTransactionId(SenderAccountId, SenderBankId, On);
        }

        private string getTransactionId(string SenderAccountId, string BankId, DateTime On)
        {
            string date = On.ToString();
            string Id = "TXN" + BankId + SenderAccountId + date;
            return Id;
        }


    }
}
