using ATM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.CLI
{
    public class TakeUserInput
    {
        public static string Input()
        {
            return Console.ReadLine();
        }

        public static string BankName()
        {
            return GetInput("Please choose a name for the bank");
        }

        public static string AccountId()
        {
            return GetInput("Please enter the account Id");
        } 

        public static string BankId()
        {
            return GetInput("please enter a Bank ID for the bank");
        }

        public static string UserName()
        {
            return GetInput("Please Enter the username");
        }

        public static string Password()
        {
            return GetInput("Enter password");
        }

        public static string DepositAmount()
        {
            return GetInput("Enter amount to deposit");
        }

        public static string WithdrawAmount()
        {
            return GetInput("Enter amount to withdraw");
        }

        public static string RecieverName()
        {
            return GetInput("Enter the name of the person you want to send to");
        }

        public static string RecieverAccountId()
        {
            return GetInput("Enter the account Id of the person you want to send to");
        }

        public static string AmountToTransfer()
        {
            return GetInput("Enter amount to transfer");
        }

        public static string NewServiceCharge()
        {
            return GetInput("Please enter the new service charge");
        }

        public static string TransactionId()
        {
            return GetInput("Please enter the transaction Id");
        }

        public static string CurrencyName()
        {
            return GetInput("please enter currency name");
        }

        public static string ExchangeRate()
        {
            return GetInput("please enter the exchange rate");
        }

        


        private static string GetInput(string message)
        {
            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine();
            string result = Console.ReadLine();
            return result;
        }
    }
}
