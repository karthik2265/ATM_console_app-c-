using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Services
{
    public class ConsoleOutput
    {
        public static void Welcome()
        {
            Console.WriteLine("Welcome to ATM");
            Console.WriteLine();
        }

        public static void LoginOrCreateAnAccount()
        {
            Console.WriteLine("Press 1 to create an account");
            Console.WriteLine("Press 2 to go to log in");
            Console.WriteLine();
        }

        public static void AccountCreationSuccesful()
        {
            Console.WriteLine();
            Console.WriteLine("Account Created Successfully");
        }

        public static void UserLoggedIn(string userName)
        {
            Console.WriteLine();
            Console.WriteLine($"{userName} is logged in");
            Console.WriteLine();
        }

        public static void ChooseAnOption()
        {
            Console.WriteLine();
            Console.WriteLine("Press 0 to log out");
            Console.WriteLine("Press 1 to deposit money");
            Console.WriteLine("Press 2 to withdraw money");
            Console.WriteLine("Press 3 to transfer money");
            Console.WriteLine("Press 4 to show transaction history");
            Console.WriteLine();
        }

        public static void SuccesfullyDeposited(double y)
        {
            Console.WriteLine();
            Console.WriteLine(y + " deposited successfully");
        }

        public static void SuccesfullyWithdrawn(double y)
        {
            Console.WriteLine();
            Console.WriteLine(y + " withdrawn successfully");
        }

        public static void SuccessfulTransfer(double amount, string accNo)
        {
            Console.WriteLine();
            Console.WriteLine($"{amount} has been succesfully transfered to {accNo}");
        }

        public static void TransactionHistory(List<string> userTransactionHistory)
        {
            Console.WriteLine("TRANSACTION HISTORY");
            foreach (string transaction in userTransactionHistory)
            {
                Console.WriteLine();
                Console.WriteLine(transaction);
            }
        }

        public static void EnterValidOption()
        {
            Console.WriteLine();
            Console.WriteLine("Enter a valid option");
        }

        public static void InSufficientBalance(double balance)
        {
            Console.WriteLine();
            Console.WriteLine("Can not complete the action due to insufficient balance");
            Console.WriteLine("Your current balance is " + balance);
        }

        public static void InvalidInput()
        {
            Console.WriteLine();
            Console.WriteLine("Please enter a valid number");
        }

    }
}
