﻿using Orleans;
using System.Transactions;

namespace AccountTransfer.Interfaces
{
    public interface IAccountGrain : IGrainWithStringKey
    {
        [Transaction(TransactionOption.Join)]
        Task Withdraw(uint amount);

        [Transaction(TransactionOption.Join)]
        Task Deposit(uint amount);

        [Transaction(TransactionOption.CreateOrJoin)]
        Task<uint> GetBalance();
    }
}
