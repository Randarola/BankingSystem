using Banking.Core.Models;
using Banking.Core.Enums;
using Banking.Infrastructure.Repositories;

namespace Banking.Server.Services
{
    public class AccountService
    {
        private readonly AccountRepository _accountRepository;
        private readonly TransactionRepository _transactionRepository;

        public AccountService(AccountRepository accountRepository, TransactionRepository transactionRepository)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
        }

        public decimal? GetBalance(int customerId)
        {
            var account = _accountRepository.GetByCustomerId(customerId);

            return account?.Balance;
        }

        public bool Deposit(string accountNumber, decimal amount)
        {
            var account = _accountRepository.GetByAccountNumber(accountNumber);
            if (account == null)
            {
                return false;
            }
            account.Deposit(amount);
            _accountRepository.Update(account);

            _transactionRepository.Add(
                  new Transaction(
                      id: _transactionRepository.GetAll().Count + 1,
                      type: TransactionType.Deposit,
                      sourceAccountNumber: null,
                      destinationAccountNumber: account.AccountNumber,
                      amount: amount,
                      timestamp: DateTime.UtcNow));

            return true;
        }
    }
}
