using System;
using ATM.Models;
using ATM.Services;

namespace ATM.CLI
{
    internal class Program
    {
        static void Main()
        {
            BankManager manager = new BankManager(1, "Alpha");

            StandardMessages.Welcome();
            StandardMessages.LoginOrCreateAnAccount();

            // take user input to create account or login
            bool createAccount = Convert.ToInt32(TakeUserInput.Input()) == 1;
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
            } while (!manager.Login(userName, password));

            StandardMessages.UserLoggedIn(userName);
            StandardMessages.ChooseAnOption();

            int option = Convert.ToInt32(TakeUserInput.Input());
            double amount;
            string input;
            int status;
            while (option != 0)
            {
                if (option == 1)
                {
                    input = TakeUserInput.DepositAmount();
                    status = (int) InputValidator.IsDepositable(input);
                    if (status == 2)
                    {
                        amount = Convert.ToDouble(TakeUserInput.DepositAmount());
                        StandardMessages.SuccesfullyDeposited(amount);
                        manager.AddTransaction(userName, $"{amount} deposited");
                        manager.UpdateBalance(userName, amount);
                    }
                    else if (status == 1) StandardMessages.InSufficientBalance(manager.GetBalance(userName));
                    else StandardMessages.InvalidInput();
                }
                else if (option == 2)
                {
                    input = TakeUserInput.WithdrawAmount();
                    status = (int) InputValidator.IsDepositable(input);
                    if (status == 2)
                    {
                        amount = Convert.ToDouble(TakeUserInput.WithdrawAmount());
                        StandardMessages.SuccesfullyWithdrawn(amount);
                        manager.AddTransaction(userName, $"{amount} withdrawn");
                        manager.UpdateBalance(userName, -amount);
                    }
                    else if (status == 1) StandardMessages.InSufficientBalance(manager.GetBalance(userName));
                    else StandardMessages.InvalidInput();
                }
                else if (option == 3)
                {

                    string accNo = TakeUserInput.AccountNo();
                    input = TakeUserInput.AmountToTransfer();
                    status = (int) InputValidator.IsDepositable(input);
                    if (status == 2)
                    {
                        amount = Convert.ToDouble(TakeUserInput.AmountToTransfer());
                        StandardMessages.SuccessfulTransfer(amount, accNo);
                        manager.AddTransaction(userName, $"{amount} has been transferred to {accNo}");
                        manager.UpdateBalance(userName, -amount);
                    }
                    else if (status == 1) StandardMessages.InSufficientBalance(manager.GetBalance(userName));
                    else StandardMessages.InvalidInput();
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
