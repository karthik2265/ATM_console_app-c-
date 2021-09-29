using System;
using ATM.Models;
using ATM.Services;

namespace ATM.CLI
{
    internal class Program
    {
        static void Main()
        {
            BankManager manager = new BankManager(new Bank(1, "Alpha"));

            StandardMessages.Welcome();
            StandardMessages.LoginOrCreateAnAccount();

            // take user input to create account or login
            bool createAccount = (Convert.ToInt32(TakeUserInput.Input()) == 1) ? true : false;
            // branch according to createAccount
            string userName;
            string password;
            if (createAccount)
            {
                // create a new account and add it to bank using bank manager

                userName = TakeUserInput.UserName();
                password = TakeUserInput.Password();
                manager.AddAccount(userName, password);
                StandardMessages.AccountCreationSuccesful();
            }
            // log in and ask user what he wants to do
            do
            {
                userName = TakeUserInput.UserName();
            } while (!manager.UserExists(userName));

            do
            {
                password = TakeUserInput.Password();
            } while (!manager.CheckPassword(userName, password));

            StandardMessages.UserLoggedIn(userName);
            StandardMessages.ChooseAnOption();

            int option = Convert.ToInt32(TakeUserInput.Input());
            while (option != 0)
            {
                if (option == 1)
                {
                    string y = TakeUserInput.DepositAmount();
                    StandardMessages.SuccesfullyDeposited(y);
                    manager.AddTransaction(userName, $"{y} deposited");

                }
                else if (option == 2)
                {
                    string x = TakeUserInput.WithdrawAmount();
                    StandardMessages.SuccesfullyWithdrawn(x);
                    manager.AddTransaction(userName, $"{x} withdrawn");

                }
                else if (option == 3)
                {

                    string accNo = TakeUserInput.AccountNo();
                    string amount = TakeUserInput.AmountToTransfer();
                    StandardMessages.SuccessfulTransfer(amount, accNo);
                    manager.AddTransaction(userName, $"{amount} has been transferred to {accNo}");

                }
                else if (option == 4)
                {
                    StandardMessages.TransactionHistory(manager.GetTransactionHistory(userName));
                }
                else
                {
                    StandardMessages.EnterValidOption();
                }

                StandardMessages.ChooseAnOption();
                option = Convert.ToInt32(TakeUserInput.Input());
            }
        }
    }
}
