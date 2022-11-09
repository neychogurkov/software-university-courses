using System;
using System.Collections.Generic;

namespace _06.MoneyTransactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] bankAccountsInfo = Console.ReadLine().Split(',');
            List<BankAccount> bankAccounts = GetBankAccounts(bankAccountsInfo);

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split();
                string commandType = cmdArgs[0];
                int accountNumber = int.Parse(cmdArgs[1]);
                double amount = double.Parse(cmdArgs[2]);

                BankAccount bankAccount = bankAccounts.Find(a => a.AccountNumber == accountNumber);

                try
                {
                    if (bankAccount == null)
                    {
                        throw new ArgumentException("Invalid account!");
                    }

                    if (commandType == "Deposit")
                    {
                        bankAccount.Balance += amount;
                    }
                    else if (commandType == "Withdraw")
                    {
                        if (bankAccount.Balance < amount)
                        {
                            throw new ArgumentException("Insufficient balance!");
                        }

                        bankAccount.Balance -= amount;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid command!");
                    }

                    Console.WriteLine(bankAccount);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }

        private static List<BankAccount> GetBankAccounts(string[] bankAccountsInfo)
        {
            List<BankAccount> bankAccounts = new List<BankAccount>();

            foreach (var bankAccountInfo in bankAccountsInfo)
            {
                string[] accountInfo = bankAccountInfo.Split('-');
                int accountNumber = int.Parse(accountInfo[0]);
                double balance = double.Parse(accountInfo[1]);

                BankAccount bankAccount = new BankAccount(accountNumber, balance);
                bankAccounts.Add(bankAccount);
            }

            return bankAccounts;
        }
    }
}
