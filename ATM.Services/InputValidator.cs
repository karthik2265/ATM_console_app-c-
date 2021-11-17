using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Models;

namespace ATM.Services
{
    public static class InputValidator 
    {

        public static InputValidation IsDepositable(string amount) {
            
            try
            {
                Convert.ToDouble(amount);
                return InputValidation.Success;
            }
            catch
            {
                return InputValidation.InvalidInput;
            }
            
        }

        public static InputValidation IsValidAmount(string amt, double balance)
        {
            try
            {
                double amount = Convert.ToDouble(amt);
                if (amount > balance) return InputValidation.InsufficientBalance;
                return InputValidation.Success;
            }
            catch
            {
                return InputValidation.InvalidInput;
            }
        }

        //public static InputValidation UserExists(BankService manager, string userName, string accountId)
        //{
        //    Customer user = manager.GetCustomer(userName);
        //    if (user == null || user.Id != accountId) return InputValidation.UserDoesntExist;
        //    else return InputValidation.Success;
        //}
    }
        
}
