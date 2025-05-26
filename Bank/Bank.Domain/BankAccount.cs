using System;

namespace Bank.Domain
{
    /// <summary>
    /// Represents a customer's bank account.
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// Message shown when attempting to debit more than the available balance.
        /// </summary>
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";

        /// <summary>
        /// Message shown when attempting to debit a negative amount.
        /// </summary>
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";

        private readonly string m_customerName;
        private double m_balance;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class with the specified customer name and initial balance.
        /// </summary>
        /// <param name="customerName">Name of the account holder.</param>
        /// <param name="balance">Initial balance of the account.</param>
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        /// <summary>
        /// Gets the name of the customer.
        /// </summary>
        public string CustomerName { get { return m_customerName; } }

        /// <summary>
        /// Gets the current balance of the account.
        /// </summary>
        public double Balance { get { return m_balance; } }

        /// <summary>
        /// Deducts a specified amount from the account balance.
        /// </summary>
        /// <param name="amount">The amount to deduct.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the amount is negative or exceeds the balance.</exception>
        public void Debit(double amount)
        {
            if (amount > m_balance)
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            if (amount < 0)
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);

            m_balance -= amount;
        }

        /// <summary>
        /// Adds a specified amount to the account balance.
        /// </summary>
        /// <param name="amount">The amount to add.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the amount is negative.</exception>
        public void Credit(double amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException("amount");

            m_balance += amount;
        }
    }
}
