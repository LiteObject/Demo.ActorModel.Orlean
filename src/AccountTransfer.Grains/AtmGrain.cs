using AccountTransfer.Interfaces;
using Orleans;
using Orleans.Concurrency;

namespace AccountTransfer.Grains
{
    /// <summary>
    /// AtmGrain, which implements IAtmGrain, simulates an "Automatic Teller Machine" which allows transfers between two bank accounts.
    /// </summary>
    [StatelessWorker]
    public class AtmGrain : Grain, IAtmGrain
    {
        public Task Transfer(IAccountGrain fromAccount, IAccountGrain toAccount, uint amountToTransfer) =>
            Task.WhenAll(
                fromAccount.Withdraw(amountToTransfer),
                toAccount.Deposit(amountToTransfer));
    }
}
