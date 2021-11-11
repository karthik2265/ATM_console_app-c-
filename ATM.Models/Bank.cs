using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Models
{
    public class Bank
    {
        public Dictionary<string, Customer> Customers;
        public Dictionary<string, Transaction> Transactions;
        public string Name;
        public string Id;
        // RTGS and IMPS rates
        public double RTGSChargeToSameBank;
        public double IMPSChargeToSameBank;
        public double RTGSChargeToOtherBanks;
        public double IMPSChargeToOtherBanks;
        // to set Id 
        private readonly DateTime currentDate;
        // accepted curreny and exchange rate
        public Currency AcceptedCurrency;
        public double ExchangeRate;
        // staff
        public Dictionary<string, Staff> Staff;

        public Bank(string id, string name, Currency acceptedCurrency)
        {
            this.Name = name;
            this.Customers = new Dictionary<string, Customer>();
            this.Transactions = new Dictionary<string, Transaction>();
            // set accountId
            currentDate = DateTime.Now;
            string date = currentDate.ToShortDateString();
            Id = "";
            for (int i = 0; i < 3; i++) Id += this.Name;
            Id += date;
            //  RTGS and IMPS rates
            this.RTGSChargeToSameBank = 0;
            this.IMPSChargeToSameBank = 5;
            this.RTGSChargeToOtherBanks = 2;
            this.RTGSChargeToOtherBanks = 6;
            // currency and exchange rate
            this.AcceptedCurrency = Currency.INR;
            this.ExchangeRate = 0;

         }
    }
}
