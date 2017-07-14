using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGBank.Models;
using SGBank.BLL.DepositRules;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using SGBank.BLL.WithdrawRules;

namespace SGBank.Tests
{
    public class PremiumAccountTests
    {
        [TestCase("99999", "Premium Account", 100, AccountType.Free, 250, false)] // fail, wrong account type
        [TestCase("99999", "Premium Account", 100, AccountType.Premium, -100, false)] // fail, negative number deposited
        [TestCase("99999", "Premium Account", 100, AccountType.Premium, 250, true)] // success
        public void PremiumAccountDepositRuleTest(string accountNumber, string name, decimal balance,
           AccountType accountType, decimal amount, bool expectedResult)
        {
            IDeposit deposit = new NoLimitDepositRule();

            Account account = new Account();

            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;

            AccountDepositResponse response = deposit.Deposit(account, amount);

            Assert.AreEqual(expectedResult, response.Success);

        }


        [TestCase("99999", "Premium Account", 100, AccountType.Free, -100, 100, false)] // fail, not a premium account type
        [TestCase("99999", "Premium Account", 100, AccountType.Premium, 100, 100, false)] // fail, positive number withdrawn
        [TestCase("99999", "Premium Account", 1500, AccountType.Premium, -1000, 500, true)] // success
        [TestCase("99999", "Premium Account", 100, AccountType.Premium, -601, 100, false)] // fail, cannot overdraft more than $500
        public void PremiumAccountWithdrawRuleTest(string accountNumber, string name, decimal balance,
            AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
        {
            IWithdraw withdraw = new PremiumAccountWithdrawRule();

            Account account = new Account();

            account.AccountNumber = accountNumber;
            account.Balance = balance;
            account.Name = name;
            account.Type = accountType;

            AccountWithdrawResponse response = withdraw.Withdraw(account, amount);

            Assert.AreEqual(expectedResult, response.Success);
            Assert.AreEqual(newBalance, account.Balance);

        }
    }
}
