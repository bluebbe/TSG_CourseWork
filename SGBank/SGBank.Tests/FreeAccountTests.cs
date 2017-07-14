using NUnit.Framework;
using SGBank.BLL;
using SGBank.Models;
using SGBank.Models.Responses;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models.Interfaces;

namespace SGBank.Tests
{
    [TestFixture]
    public class FreeAccountTests
    {
        [Test]
        public void CanLoadFreeAccountTestData()
        {
            AccountManager manager = AccountManagerFactory.Create();

            AccountLookupResponse response = manager.LookupAccount("12345");

            Assert.IsNotNull(response.Account);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("12345", response.Account.AccountNumber);
        }


        [TestCase("12345","Free Account",100,AccountType.Free,250,false)] // fail, too much deposited
        [TestCase("12345", "Free Account", 100, AccountType.Free, -100, false)] // fail, negative number deposited
        [TestCase("12345", "Free Account", 100, AccountType.Basic, 250, false)] // fail, not a free account type
        [TestCase("12345", "Free Account", 100, AccountType.Free, 50, true)] // fail, too much deposited
        public void FreeAccountDepositRuleTest(string accountNumber, string name, 
                            decimal balance,AccountType accountType, decimal amount, bool expectResult)
        {
            IDeposit rule = new FreeAccountDepositRule() ;

            Account account = new Account();

            account.AccountNumber =accountNumber;
            account.Balance = balance;
            account.Name = name;
            account.Type = accountType;

            AccountDepositResponse response = rule.Deposit(account, amount);

            Assert.AreEqual(expectResult, response.Success);
            
       
        }


        [TestCase("12345", "Free Account", 200, AccountType.Free, 10, false)] // Positive withdrawal amount (fail)
        [TestCase("12345", "Free Account", 200, AccountType.Free, -110, false)] // Negative withdrawal over limit (fail)
        [TestCase("12347", "Free Account", 200, AccountType.Basic, 250, false)] // Wrong account type (fail)
        [TestCase("12345", "Free Account", 75, AccountType.Free, -90, false)] // Overdraft (fail)
        [TestCase("12345", "Free Account", 100, AccountType.Free, -75, true)] // Successful withdrawal (succeed)


        public void FreeAccountWithdrawRuleTest(string accountNumber, string name,
                            decimal balance, AccountType accountType, decimal amount, bool expectResult)

        {
            IWithdraw rule = new FreeAccountWithdrawRule();

            Account account = new Account();

            account.AccountNumber = accountNumber;
            account.Balance = balance;
            account.Name = name;
            account.Type = accountType;

            AccountWithdrawResponse response = rule.Withdraw(account, amount);


            Assert.AreEqual(expectResult, response.Success);

        }
            
            
    }
}
