using Banking.Infrastructure.Repositories;
using Banking.Core.Models;
using Banking.Core.Enums;

namespace Banking.Server.Services
{
    public class TransferService
    {
        private readonly AccountRepository _accountRepository;
        private readonly TransactionRepository _transactionRepository;

        public TransferService(AccountRepository accountRepository, TransactionRepository transactionRepository)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
        }

        public bool Transfer(string sourceAccountNumber, string destinationAccountNumber, decimal amount)
        {
            var sourceAccount = _accountRepository.GetByAccountNumber(sourceAccountNumber);
            var destinationAccount = _accountRepository.GetByAccountNumber(destinationAccountNumber);
            if (sourceAccount == null || destinationAccount == null)
            {
                return false; // One of the accounts does not exist
            }
            if (!sourceAccount.Withdraw(amount))
            {
                return false; // Insufficient funds
            }
            destinationAccount.Deposit(amount);
            _accountRepository.Update(sourceAccount);
            _accountRepository.Update(destinationAccount);
            _transactionRepository.Add(
                new Transaction(
                    id: _transactionRepository.GetAll().Count + 1,
                    type: TransactionType.Transfer,
                    sourceAccountNumber: sourceAccount.AccountNumber,
                    destinationAccountNumber: destinationAccount.AccountNumber,
                    amount: amount,
                    timestamp: DateTime.UtcNow));
            return true;
        }
    }
}
