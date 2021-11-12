using System;
using System.Collections.Generic;

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
        private DateTime currentDate;
        // accepted curreny and exchange rate
        public string AcceptedCurrency;
        public double ExchangeRate;
        // staff
        public Dictionary<string, Staff> Staff;

       

        public Bank(string id, string name, string acceptedCurrency)
        {
            this.Name = name;
            this.Customers = new Dictionary<string, Customer>();
            this.Transactions = new Dictionary<string, Transaction>();
            // set Id
            this.Id = setId(name);
            //  RTGS and IMPS rates
            this.RTGSChargeToSameBank = 0;
            this.IMPSChargeToSameBank = 5;
            this.RTGSChargeToOtherBanks = 2;
            this.RTGSChargeToOtherBanks = 6;
            // currency and exchange rate
            this.AcceptedCurrency = "INR";
            this.ExchangeRate = 1;

        }

        public Bank(string name, string id, double RTGSChargeToSameBank, double IMPSChargeToSameBank, double RTGSChargeToOtherBanks, double IMPSChargeToOtherBanks, string acceptedCurrency, double exchangeRate): this(id, name, acceptedCurrency)
        {
            //  RTGS and IMPS rates
            this.RTGSChargeToSameBank = RTGSChargeToSameBank;
            this.IMPSChargeToSameBank = IMPSChargeToSameBank;
            this.RTGSChargeToOtherBanks = RTGSChargeToOtherBanks;
            this.RTGSChargeToOtherBanks = IMPSChargeToOtherBanks;
            // currency and exchange rate
            this.AcceptedCurrency = acceptedCurrency;
            this.ExchangeRate = exchangeRate;
        }

        private string setId(string name)
        {
            DateTime currentDate = DateTime.Now;
            string date = currentDate.ToShortDateString();
            string Id = "";
            for (int i = 0; i < 3; i++) Id += name;
            Id += date;
            return Id;
        }



    }
}
