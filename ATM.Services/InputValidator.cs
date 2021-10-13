using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Services
{
    public static class InputValidator
    {

        public static ValidationStatus IsDepositable(string amount) {
            
            try
            {
                Convert.ToDouble(amount);
                return ValidationStatus.Success;
            }
            catch
            {
                return ValidationStatus.InvalidInput;
            }
            
        }

        public static ValidationStatus IsValidAmount(string amt, double balance)
        {
            try
            {
                double amount = Convert.ToDouble(amt);
                if (amount > balance) return ValidationStatus.InsufficientBalance;
                return ValidationStatus.Success;
            }
            catch
            {
                return ValidationStatus.InvalidInput;
            }
        }
    }
        
}
