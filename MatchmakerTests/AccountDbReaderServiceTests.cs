﻿using System.Linq;
using System.Threading.Tasks;
using AmoebaGameMatcherServer.Services;
using DataLayer;
using DataLayer.Tables;
using MatchmakerTest.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchmakerTest
{
    [TestClass]
    public class AccountDbReaderServiceTests
    {
        /// <summary>
        /// Сервис нормально достаёт данные про аккаунт из БД
        /// </summary>
        [TestMethod]
        public async Task Test1()
        {
            //Arrange
            ApplicationDbContext dbContext = new InMemoryDatabaseFactory(nameof(AccountDbReaderServiceTests))
                .Create();
            AccountDbReaderService accountDbReaderService = new AccountDbReaderService(dbContext);
            Account account = AccountFactory.CreateSimpleAccount();
            await dbContext.Accounts.AddAsync(account);
            await dbContext.SaveChangesAsync();
            
            //Act
            var playerInfo = await accountDbReaderService.GetAccountInfo(account.ServiceId);
            
            //Assert
            Assert.IsNotNull(playerInfo);
            
            int accountRating = await dbContext.Warships
                .Where(warship => warship.AccountId == account.Id)
                .SumAsync(warship => warship.Rating);
            
            Assert.AreEqual(account.Username, playerInfo.Username);
            Assert.AreEqual(accountRating, playerInfo.AccountRating);
            Assert.AreEqual(account.PremiumCurrency, playerInfo.PremiumCurrency);
            Assert.AreEqual(account.RegularCurrency, playerInfo.RegularCurrency);
            Assert.AreEqual(account.PointsForBigChest, playerInfo.PointsForBigChest);
            Assert.AreEqual(account.PointsForSmallChest, playerInfo.PointsForSmallChest);
        }
        
        /// <summary>
        /// Если аккаунта в БД нет, то сервис вернёт null
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Test2()
        {
            //Arrange
            ApplicationDbContext dbContext = new InMemoryDatabaseFactory(nameof(AccountDbReaderServiceTests))
                .Create();
            AccountDbReaderService accountDbReaderService = new AccountDbReaderService(dbContext);
            string accountServiceId = "someUniqueId_65461814865468";
            
            //Act
            var playerInfo = await accountDbReaderService.GetAccountInfo(accountServiceId);
            
            //Assert
            Assert.IsNull(playerInfo);
        }
    }
}