using ATM.Models;
using System;
using System.Collections.Generic;

namespace ATM.Services
{
    public class ConsoleOutput
    {
        public static void Welcome()
        {
            Console.WriteLine("Welcome to ATM");
            Console.WriteLine();
        }

        public static void Mainmenu()
        {
            Console.WriteLine();
            Console.WriteLine("Please choose an option");
            Console.WriteLine("Press 0 to setup a Bank");
            Console.WriteLine("Press 1 to Account holder login");
            Console.WriteLine("Press 2 to Staff login");
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

        public static void StaffMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Press 0 to log out");
            Console.WriteLine("Press 1 to create a new Account");
            Console.WriteLine("Press 2 to update account status");
            Console.WriteLine("Press 3 to update accepted currency");
            Console.WriteLine("Press 4 to update service charges");
            Console.WriteLine("Press 5 to view transaction history");
            Console.WriteLine("Press 6 to revert a transaction");
            Console.WriteLine();
        }

        public static void CustomerMenu()
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

        public static void TransactionHistory(List<Transaction> userTransactionHistory)
        {
            Console.WriteLine();
            Console.WriteLine("TRANSACTION HISTORY");
            foreach (var transaction in userTransactionHistory)
            {
                Console.WriteLine();
                Console.WriteLine("Transaction Id: " + transaction.Id + " Type: " + transaction.Type + " amount: " + transaction.Amount);
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

        public static void UserDoesntExist()
        {
            Console.WriteLine();
            Console.WriteLine("Sorry not able to find a user with given details");
        }

        public static void UpdateAccountStatusOptions()
        {
            Console.WriteLine();
            Console.WriteLine("please choose an option");
            Console.WriteLine("press 0 to change the account status to active");
            Console.WriteLine("press 1 to change the account status to Inactive");
            Console.WriteLine("press 0 to change the account status to paused");
            Console.WriteLine();
        }

        public static void UpdateServiceChargesOptions()
        {
            Console.WriteLine();
            Console.WriteLine("please choose an option");
            Console.WriteLine("press 0 to change the RTGS charges for same bank");
            Console.WriteLine("press 1 to change the RTGS charges for other banks");
            Console.WriteLine("press 2 to change the IMPS charges for same bank");
            Console.WriteLine("press 3 to change the IMPS charges for other banks");
            Console.WriteLine();

        }

        public static void SuccesfullyUpdated()
        {
            Console.WriteLine();
            Console.WriteLine("Successfully Updated");
            Console.WriteLine();
        }




    }
}
