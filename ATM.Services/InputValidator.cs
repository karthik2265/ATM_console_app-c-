using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Services
{
    public static class InputValidator
    {
        public enum Status
        {
            InvalidInput,
            InsufficientBalance,
            Success
        }

        public static Status IsDepositable(string amount) {
            
            try
            {
                Convert.ToDouble(amount);
                return Status.Success;
            }
            catch
            {
                return Status.InvalidInput;
            }
            
        }

        public static Status IsValidAmount(string amt, double balance)
        {
            try
            {
                double amount = Convert.ToDouble(amt);
                if (amount > balance) return Status.InsufficientBalance;
                return Status.Success;
            }
            catch
            {
                return Status.InvalidInput;
            }
        }
    }
        
}
