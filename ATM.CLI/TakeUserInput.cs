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

        public static string AccountNo()
        {
            return GetInput("Enter the account number");
        }

        public static string AmountToTransfer()
        {
            return GetInput("Enter amount to transfer");
        }

        private static string GetInput(string message)
        {
            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine();
            return Console.ReadLine();
        }
    }
}
