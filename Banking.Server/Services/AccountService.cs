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
    }
}
