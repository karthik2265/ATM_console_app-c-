using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Models;
using ATM.Models.enums;

namespace ATM.Services
{
    public class StaffService : BankService
    {
        public Staff Staff;

        public StaffService(string id, string name, StaffAcessLevel acessLevel = StaffAcessLevel.StaffMember) : base(id, name)
        {
           Staff = new Staff(id, name, acessLevel);
        }

        public bool FindAccount(string accId)
        {
            foreach (var x in AlphaBank.Customers)
            {
                Customer c = x.Value;
                if (c.Id == accId) return true;
            }
            return false;
        }

        public bool UpdateAccountStatus(string accId, AccountStatus status)
        {
            Customer c = null;
            foreach (var x in AlphaBank.Customers)
            {
                c = x.Value;
                if (c.Id == accId) break;
            }
            if (c != null)
            {
                c.Status = status;
                return true;
            }
            return false;
        }

        public bool UpdateServiceCharges(BankServiceCharges toBeUpdated, double newCharge)
        {
            if (toBeUpdated == BankServiceCharges.RTGSChargeForSameBank)
            {
                AlphaBank.RTGSChargeToSameBank = newCharge;
            }
            else if (toBeUpdated == BankServiceCharges.RTGSChargeForOtherBanks)
            {
                AlphaBank.RTGSChargeToOtherBanks = newCharge;
            }
            else if (toBeUpdated == BankServiceCharges.IMPSChargeForSameBank)
            {
                AlphaBank.IMPSChargeToSameBank = newCharge;
            }
            else if (toBeUpdated == BankServiceCharges.IMPSChargeForOtherBanks)
            {
                AlphaBank.IMPSChargeToOtherBanks = newCharge;
            }

            return true;
        }

        //public bool RevertTransaction(string txnId)
        //{
        //    if (AlphaBank.Transactions.ContainsKey(txnId))
        //    {
        //        Transaction transaction = AlphaBank.Transactions[txnId];
        //        double amount = transaction.Amount;
        //        Customer sender = GetCustomer(transaction.SenderAccountId);
        //        Customer reciever = GetCustomer(transaction.RecieverAccountId);
        //        TransferAmount(reciever, sender, amount);
        //        AddTransaction(reciever, sender, amount, TransactionType.Credit);
        //        AddTransaction(sender, reciever, amount, TransactionType.Debit);
        //        return true;
        //    }
        //    return false;
        //}

        public bool UpdateCurrencyAndExchangerate(string currency, double exchangerate)
        {
            Currency newCurrency = (Currency) Enum.Parse(typeof(Currency), currency, true);
            AlphaBank.AcceptedCurrency = newCurrency;
            AlphaBank.ExchangeRate = exchangerate;
            return true;
        } 

    }
}
