using System;
using System.Collections.Generic;

namespace ATM.Models
{
    public class Bank
    {
       
        public string Name;
        public string Id;
        // RTGS and IMPS rates
        public double RTGSChargeToSameBank;
        public double IMPSChargeToSameBank;
        public double RTGSChargeToOtherBanks;
        public double IMPSChargeToOtherBanks;
        // accepted curreny and exchange rate
        public Currency Currency;
        public double ExchangeRate;

       


       

        public Bank(string name, double RTGSChargeToSameBank = 0, double IMPSChargeToSameBank = 0, double RTGSChargeToOtherBanks = 0, double IMPSChargeToOtherBanks = 0, Currency currency = Currency.INR, double exchangeRate = 1)
        {
            this.Name = name;
            this.RTGSChargeToSameBank = RTGSChargeToSameBank;
            this.IMPSChargeToSameBank = IMPSChargeToSameBank;
            this.RTGSChargeToOtherBanks = RTGSChargeToOtherBanks;
            this.RTGSChargeToOtherBanks = IMPSChargeToOtherBanks;
            this.Id = SetId(name);
            this.Currency = currency;
            this.ExchangeRate = exchangeRate;
        }

        private static string SetId(string name)
        {
            DateTime currentDate = DateTime.Now;
            string date = currentDate.ToShortDateString();
            string Id = "";
            for (int i = 0; i < 3; i++) Id += name[i];
            Id += date;
            return Id;
        }



    }
}
