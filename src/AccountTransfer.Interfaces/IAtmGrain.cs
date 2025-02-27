using Orleans;

namespace AccountTransfer.Interfaces
{
    public interface IAtmGrain : IGrainWithIntegerKey
    {
        /*
         * The [Transaction(option)] attributes on the grain methods tell the runtime that these methods are transactional.
         */

        /// <summary>
        /// The Transfer method creates a transation to withdraws the specified amount from one IAccountGrain and deposits it in the other.
        /// Orleans ensures that this occurs in the context of a transaction to ensure consistency.
        /// </summary>
        /// <param name="fromAccount"></param>
        /// <param name="toAccount"></param>
        /// <param name="amountToTransfer"></param>
        /// <returns></returns>
        [Transaction(TransactionOption.Create)]
        Task Transfer(IAccountGrain fromAccount, IAccountGrain toAccount, uint amountToTransfer);
    }
}
