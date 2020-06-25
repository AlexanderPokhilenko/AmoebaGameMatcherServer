﻿using System.Threading.Tasks;
using DataLayer.Tables;
using LibraryForTests;
using NetworkLibrary.NetworkLibrary.Http;
using NUnit.Framework;

namespace IntegrationTests
{
    [TestFixture]
    internal sealed class NotShownRewardsTests : BaseIntegrationFixture
    {
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(26)]
        [TestCase(268)]
        [TestCase(26821)]
        [TestCase(268213)]
        public async Task CorrectReadingTest(int randomSeed)
        {
            //Arrange
            AccountBuilder accountBuilder = new AccountBuilder(randomSeed);
            AccountDirector accountDirector = new BigAccountDirector(accountBuilder, Context);
            accountDirector.WriteToDatabase();
            Account originalAccount = accountDirector.GetAccount();
            int notShownSoftCurrencyDelta = accountDirector.GetNotShownSoftCurrencyDelta();
            int notShownHardCurrencyDelta = accountDirector.GetNotShownHardCurrencyDelta();
            int notShownAccountRatingDelta = accountDirector.GetNotShownAccountRatingDelta();
            int notShownLootboxPointsDelta = accountDirector.GetNotShownLootboxPointsDelta();
            
            //Act
            RewardsThatHaveNotBeenShown result = await NotShownRewardsReaderService
                .GetNotShownRewardAndMarkAsRead(originalAccount.ServiceId);
            
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(notShownSoftCurrencyDelta, result.SoftCurrencyDelta);
            Assert.AreEqual(notShownAccountRatingDelta, result.AccountRatingDelta);
            Assert.AreEqual(notShownHardCurrencyDelta, result.HardCurrencyDelta);
            Assert.AreEqual(notShownLootboxPointsDelta, result.LootboxPointsDelta);
        }
        
        
        /// <summary>
        /// После первого запроса все транзакции должны быть отмечены как прочитанные.
        /// Тоесть второй запрос вернёт все нули.
        /// </summary>
        /// <param name="randomSeed"></param>
        /// <returns></returns>
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(26)]
        [TestCase(268)]
        [TestCase(26821)]
        [TestCase(268213)]
        public async Task CorrectMarkingTest(int randomSeed)
        {
            //Arrange
            AccountBuilder accountBuilder = new AccountBuilder(randomSeed);
            AccountDirector accountDirector = new BigAccountDirector(accountBuilder, Context);
            accountDirector.WriteToDatabase();
            Account originalAccount = accountDirector.GetAccount();
                        
            //Act
            RewardsThatHaveNotBeenShown result1 =await NotShownRewardsReaderService
                .GetNotShownRewardAndMarkAsRead(originalAccount.ServiceId);
            
            RewardsThatHaveNotBeenShown result2 = await NotShownRewardsReaderService
                .GetNotShownRewardAndMarkAsRead(originalAccount.ServiceId);

            
            //Assert
            Assert.IsNotNull(result1);
            Assert.AreNotEqual(0, result1.AccountRatingDelta);
            Assert.AreNotEqual(0, result1.LootboxPointsDelta);
            Assert.AreNotEqual(0, result1.SoftCurrencyDelta);
            
            Assert.IsNotNull(result2);
            Assert.AreEqual(0, result2.SoftCurrencyDelta);
            Assert.AreEqual(0, result2.AccountRatingDelta);
            Assert.AreEqual(0, result2.HardCurrencyDelta);
            Assert.AreEqual(0, result2.LootboxPointsDelta);
        }
    }
}