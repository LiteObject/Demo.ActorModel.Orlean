using AccountTransfer.Interfaces;
using Orleans;
using Orleans.Transactions.Abstractions;

namespace AccountTransfer.Grains
{
    /// <summary>
    /// AccountGrain, which implements IAccountGrain, simulates a bank account with an balance.
    /// </summary>
    public class AccountGrain : Grain, IAccountGrain
    {
        private readonly ITransactionalState<Balance> _balance;

        public AccountGrain(
            [TransactionalState("balance")] ITransactionalState<Balance> balance) =>
            _balance = balance ?? throw new ArgumentNullException(nameof(balance));

        /// <summary>
        /// The Deposit method adds the deposited amount to the account balance using the ITransactionalState<T>.PerformUpdate method
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public Task Deposit(uint amount) =>
            _balance.PerformUpdate(
                balance => balance.Value += amount);

        public Task Withdraw(uint amount) =>
            _balance.PerformUpdate(balance =>
            {
                // prevents overdrawing by throwing an exception, causing the transaction to be aborted
                if (balance.Value < amount)
                {
                    throw new InvalidOperationException(
                        $"Withdrawing {amount} credits from account " +
                        $"\"{this.GetPrimaryKeyString()}\" would overdraw it." +
                        $" This account has {balance.Value} credits.");
                }

                balance.Value -= amount;
            });

        public Task<uint> GetBalance() =>
            _balance.PerformRead(balance => balance.Value);
    }
}
