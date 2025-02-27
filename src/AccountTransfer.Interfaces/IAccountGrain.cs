using Orleans;
using System.Transactions;

namespace AccountTransfer.Interfaces
{
    public interface IAccountGrain : IGrainWithStringKey
    {
        /*
         * The [Transaction(option)] attributes on the grain methods tell the runtime that these methods are transactional.
         */

        /// <summary>
        /// The Withdraw and Deposit methods must be called in the context of an existing transactions.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        [Transaction(TransactionOption.Join)]
        Task Withdraw(uint amount);

        /// <summary>
        /// The Withdraw and Deposit methods must be called in the context of an existing transactions.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        [Transaction(TransactionOption.Join)]
        Task Deposit(uint amount);

        [Transaction(TransactionOption.CreateOrJoin)]
        Task<uint> GetBalance();
    }
}
