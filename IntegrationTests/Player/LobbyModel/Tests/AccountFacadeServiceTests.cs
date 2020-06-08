﻿using System.Linq;
using System.Threading.Tasks;
using DataLayer.Tables;
using LibraryForTests;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace IntegrationTests
{
    [TestFixture]
    internal sealed class AccountFacadeServiceTests : BaseIntegrationFixture
    {
        /// <summary>
        /// Сервис создаст аккаунт с таким serviceId, если такого нет в БД.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ServiceCreatesAnAccountIfItIsNot()
        {
            //Arrange
            string serviceId = "someServiceId";
            //Act
            var account = await AccountFacadeService.ReadOrCreateAccount(serviceId);
            var account1 = await Context.Accounts
                .Where(acc => acc.ServiceId == serviceId)
                .SingleAsync();
            
            //Assert
            Assert.IsNotNull(account);
            Assert.IsNotNull(account1);
        }
        
        /// <summary>
        /// Сервис достанет существующий аккаунт, если он есть.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ServiceReadsAccountIfOneExists()
        {
            //Arrange
            AccountBuilder accountBuilder = new AccountBuilder(2);
            AccountDirector accountDirector = new SmallAccountDirector(accountBuilder, Context);
            accountDirector.WriteToDatabase();
            Account originalAccount = accountBuilder.GetAccount(); 
            
            //Act
            var account = await AccountFacadeService.ReadOrCreateAccount(originalAccount.ServiceId);
           
            //Assert
            Assert.IsNotNull(account);
            Assert.AreEqual(originalAccount.Id, account.Id);
        }
    }
}