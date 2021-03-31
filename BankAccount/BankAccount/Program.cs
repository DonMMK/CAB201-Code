using System;
using System.IO;

using static System.Console;

namespace Bank
{
    public class Account
    {
        // Private variables: account balance, interest rate
        private decimal BankAccount;
        private decimal Interest;

        /// <summary>
        /// Creates a new bank account with zero starting balance and the default
        /// interest rate of 4.6%.
        /// </summary>
        public Account()
        {
            BankAccount = 0;
            Interest = 4.6m;
        }

        /// <summary>
        /// Creates a new bank account with a starting balance and the default
        /// interest rate of 4.6%.
        /// </summary>
        /// <param name="startingBalance">The starting balance</param>
        public Account(decimal startingBalance)
        {
            BankAccount = startingBalance;
            Interest = 4.6M ;
        }

        /// <summary>
        /// Creates a new bank account with designated starting balance and 
        /// interest rate.
        /// </summary>
        /// <param name="startingBalance">The starting balance</param>
        /// <param name="interestRate">The interest rate (expressed as a percentage)</param>
        public Account(decimal startingBalance, decimal interestRate)
        {
            BankAccount = startingBalance;
            Interest = interestRate;
        }

        /// <summary>
        ///     Attempt to reduce the balance of the bank account by 'amount'. Funds will
        ///     only be deducted if amount is less than the current balance.
        /// </summary>
        /// <param name="amount">
        ///     The amount of money to (try to) deduct from the account.
        /// </param>
        /// <returns>
        ///     True if and only if funds were deducted from the account.
        /// </returns>
        public bool Withdraw(decimal amount)
        {
            if ((BankAccount - amount )<=0)
            {
                return false;
            }
            else
            {
                BankAccount -= amount;
                return true;
            }
        }

        /// <summary>
        /// Increase the balance of the account by 'amount'
        /// </summary>
        /// <param name="amount">The amount to increase the balance by</param>
        public void Deposit(decimal amount)
        {
            BankAccount += amount;
        }

        /// <summary>
        /// Returns the total balance currently in the account.
        /// </summary>
        /// <returns>The total balance currently in the account</returns>
        public decimal QueryBalance()
        {
            return BankAccount;
        }

        /// <summary>
        /// Sets the account's interest rate to the rate provided
        /// </summary>
        /// <param name="interestRate">The interest rate for this account (%)
        /// </param>
        public void SetInterest(decimal interestRate)
        {
            Interest = interestRate;
        }

        /// <summary>
        /// Returns the account's interest rate
        /// </summary>
        /// <returns>The percentage interest rate of this account</returns>
        public decimal GetInterest()
        {
            return Interest;
        }

        /// <summary>
        /// Calculates the interest on the current account balance and adds it
        /// to the account
        /// </summary>
        public void AddInterest()
        {
            BankAccount += (BankAccount * (Interest/100));
        }

        /// <summary>
        ///     Test driver for Bank.Account.
        ///     Interactively queries user for deposit amount, withdrawal amount,
        ///     and interest rate, applies operation and displays results.
        /// </summary>
        public static void Main()
        {
            Account acct = new Account();
            bool finished = false;

            while (!finished)
            {
                Write(menu);
                var line = ReadLine();

                if (line == null) break;

                var fields = line.Trim().ToLower().Split(' ');

                if (fields.Length > 0 && fields[0].Length > 0)
                {
                    decimal deposit;
                    decimal withdrawal;
                    decimal interestRate;

                    switch (fields[0][0])
                    {
                        case 'n':
                            switch (fields.Length)
                            {
                                case 1:
                                    acct = new Account();
                                    break;
                                case 2:
                                    deposit = decimal.Parse(fields[1]);
                                    acct = new Account(deposit);
                                    break;
                                case 3:
                                    deposit = decimal.Parse(fields[1]);
                                    interestRate = decimal.Parse(fields[2]);
                                    acct = new Account(deposit, interestRate);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 'd':
                            if (fields.Length > 1)
                            {
                                deposit = decimal.Parse(fields[1]);
                                acct.Deposit(deposit);
                            }
                            break;
                        case 'w':
                            if (fields.Length > 1)
                            {
                                withdrawal = decimal.Parse(fields[1]);
                                acct.Withdraw(withdrawal);
                            }
                            break;
                        case 'i':
                            acct.AddInterest();
                            break;
                        case 'r':
                            if (fields.Length > 1)
                            {
                                interestRate = decimal.Parse(fields[1]);
                                acct.SetInterest(interestRate);
                            }
                            break;
                        case 'q':
                            finished = true;
                            break;
                        default:
                            break;
                    }
                }

                if (!finished)
                {
                    var balance = acct.QueryBalance();
                    var interest = acct.GetInterest();
                    WriteLine($"After operation: balance = {balance:0.0000000000}, interest rate = {interest:0.0000000000}");
                }
            }
        }

        static readonly string menu =
            "Enter option:\n   n = new a/c;  d = deposit;  w = withdraw;  i = apply interest;  r = new interest rate;  q = exit.\n==> ";
    }
}
