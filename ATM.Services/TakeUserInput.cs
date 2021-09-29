using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Services
{
    public class TakeUserInput
    {
        public static string Input()
        {
            return Console.ReadLine();
        }

        public static string UserName()
        {
            string userName = "";
            Console.WriteLine();
            Console.WriteLine("Please Enter the username");
            userName = Console.ReadLine();
            return userName;
        }

        public static string Password()
        {
            string password = "";
            Console.WriteLine();
            Console.WriteLine("Enter password");
            password = Console.ReadLine();
            return password;
        }

        public static string DepositAmount()
        {
            Console.WriteLine();
            Console.WriteLine("Enter amount to deposit");
            string y = Console.ReadLine();
            return y;
        }

        public static string WithdrawAmount()
        {
            Console.WriteLine();
            Console.WriteLine("Enter amount to withdraw");
            string y = Console.ReadLine();
            return y;
        }

        public static string AccountNo()
        {
            Console.WriteLine();
            Console.WriteLine("Enter the account number");
            string accNo = Console.ReadLine();
            return accNo;
        }

        public static string AmountToTransfer()
        {
            Console.WriteLine();
            Console.WriteLine("Enter amount to transfer");
            Console.WriteLine();
            string amount = TakeUserInput.Input();
            return amount;
        }
    }
}
