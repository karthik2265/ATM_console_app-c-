using System;
using ATM.Models;
using ATM.Services;

namespace ATM.CLI
{
    internal class Program
    {
        enum Options
        {
            Quit,
            Deposit,
            Withdraw,
            Transfer,
            History
        }

        enum Status
        {
            InvalidInput,
            InsufficientBalance,
            Success
        }
        static void Main()
        {
            BankManager manager = new BankManager(1, "Alpha");

            StandardMessages.Welcome();
            StandardMessages.LoginOrCreateAnAccount();

            // take user input to create account or login
            bool createAccount = Convert.ToInt32(TakeUserInput.Input()) == 1;
            // branch according to createAccount
            string customerName;
            string password;
            if (createAccount)
            {
                // create a new account and add it to bank using bank manager

                customerName = TakeUserInput.UserName();
                password = TakeUserInput.Password();
                manager.AddAccount(customerName, password);
                StandardMessages.AccountCreationSuccesful();
            }
            // log in and ask user what he wants to do
            do
            {
                customerName = TakeUserInput.UserName();
            } while (!manager.CustomerExists(customerName));

            do
            {
                password = TakeUserInput.Password();
            } while (!manager.Login(customerName, password));

            StandardMessages.UserLoggedIn(customerName);
            StandardMessages.ChooseAnOption();

            Options option = (Options) Convert.ToInt32(TakeUserInput.Input());
        
            Status status;
            while (option != Options.Quit)
            {
                if (option == Options.Deposit)
                {
                    string depositInput = TakeUserInput.DepositAmount();
                    status = (Status) InputValidator.IsDepositable(depositInput);
                    if (status == Status.Success)
                    {
                        double depositAmount = Convert.ToDouble(depositInput);
                        StandardMessages.SuccesfullyDeposited(depositAmount);
                        manager.AddTransaction(customerName, $"{depositAmount} deposited");
                        manager.DepositAmount(customerName, depositAmount);
                    }
                    else if (status == Status.InsufficientBalance) StandardMessages.InSufficientBalance(manager.GetBalance(customerName));
                    else StandardMessages.InvalidInput();
                }
                else if (option == Options.Withdraw)
                {
                    string withdrawInput = TakeUserInput.WithdrawAmount();
                    status = (Status) InputValidator.IsValidAmount(withdrawInput, manager.GetBalance(customerName));
                    if (status == Status.Success)
                    {
                        double withdrawAmount = Convert.ToDouble(withdrawInput);
                        StandardMessages.SuccesfullyWithdrawn(withdrawAmount);
                        manager.AddTransaction(customerName, $"{withdrawAmount} withdrawn");
                        manager.WithdrawAmount(customerName, withdrawAmount);
                    }
                    else if (status == Status.InsufficientBalance) StandardMessages.InSufficientBalance(manager.GetBalance(customerName));
                    else StandardMessages.InvalidInput();
                }
                else if (option == Options.Transfer)
                {

                    string recieverName = TakeUserInput.RecieverName();
                    string transferInput = TakeUserInput.AmountToTransfer();
                    status = (Status) InputValidator.IsValidAmount(transferInput, manager.GetBalance(customerName));
                    if (status == Status.Success)
                    {
                        double transferAmount = Convert.ToDouble(transferInput);
                        StandardMessages.SuccessfulTransfer(transferAmount, recieverName);
                        manager.AddTransaction(customerName, $"{transferAmount} has been transferred to {recieverName}");
                        manager.TransferAmount(customerName, transferAmount, recieverName);
                    }
                    else if (status == Status.InsufficientBalance) StandardMessages.InSufficientBalance(manager.GetBalance(customerName));
                    else StandardMessages.InvalidInput();
                }
                else if (option == Options.History)
                {
                    StandardMessages.TransactionHistory(manager.GetTransactionHistory(customerName));
                }
                else
                {
                    StandardMessages.EnterValidOption();
                }

                StandardMessages.ChooseAnOption();
                option = (Options) Convert.ToInt32(TakeUserInput.Input());
            }
        }
    }
}
