﻿using System;
using System.Threading.Tasks;
using DataLayer.Tables;
using LibraryForTests;
using Microsoft.AspNetCore.Mvc;
using NetworkLibrary.NetworkLibrary.Http;
using NUnit.Framework;
using ZeroFormatter;

namespace IntegrationTests
{
    [TestFixture]
    internal sealed class LobbyControllerTests : BaseIntegrationFixture
    {
         /// <summary>
        /// Сервис создаст аккаунт с таким serviceId, если такого нет в БД,
        /// и вернёт заполненный LobbyModel
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ServiceCreatesAnAccountIfItIsNot()
        {
            //Arrange
            string serviceId = "someServiceId";
            //Act
            ActionResult<string> resultObj = await LobbyModelController.Create(serviceId);
            string base64String = resultObj.Value;
            byte[] data = Convert.FromBase64String(base64String);
            LobbyModel lobbyModel = ZeroFormatterSerializer.Deserialize<LobbyModel>(data);
            
            //Assert
            Assert.IsNotNull(lobbyModel);
            Assert.IsNotNull(lobbyModel.AccountDto);
            Assert.IsNotNull(lobbyModel.AccountDto.Warships);
            Assert.IsTrue(lobbyModel.AccountDto.Warships.Count>1);
            Assert.IsNotNull(lobbyModel.WarshipPowerScaleModel);
            Assert.IsNotNull(lobbyModel.WarshipRatingScaleModel);
            Assert.IsNotNull(lobbyModel.RewardsThatHaveNotBeenShown);

            foreach (var warshipDto in lobbyModel.AccountDto.Warships)
            {
                Assert.IsNotNull(warshipDto.Description);
                Assert.IsNotNull(warshipDto.PrefabName);
                Assert.IsNotNull(warshipDto.CombatRoleName);
            }
        }
         
         /// <summary>
        /// Сервис нормально прочитает аккаунт, который есть в БД, и отобразит в сериализуемый класс
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ServiceReadsAccountIfOneExists()
        {
            //Arrange
            AccountBuilder accountBuilder = new AccountBuilder(65184);
            AccountDirector accountDirector = new BigAccountDirector(accountBuilder, Context);
            accountDirector.WriteToDatabase();
            Account originalAccount = accountDirector.GetAccount();
            int originalAccountRating = accountDirector.GetAccountRating();
            int accountSoftCurrency = accountDirector.GetAccountSoftCurrency();
            int accountHardCurrency = accountDirector.GetAccountHardCurrency();
            //Act
            LobbyModel lobbyModel = await LobbyModelFacadeService.CreateAsync(originalAccount.ServiceId);
            
            //Assert
            Assert.AreEqual(originalAccountRating, lobbyModel.AccountDto.AccountRating);
            Assert.AreEqual(accountSoftCurrency, lobbyModel.AccountDto.SoftCurrency);
            Assert.AreEqual(accountHardCurrency, lobbyModel.AccountDto.HardCurrency);
            Assert.IsNotNull(lobbyModel);
            Assert.IsNotNull(lobbyModel.AccountDto);
            Assert.IsNotNull(lobbyModel.AccountDto.Warships);
            Assert.IsTrue(lobbyModel.AccountDto.Warships.Count>1);
            Assert.IsNotNull(lobbyModel.WarshipPowerScaleModel);
            Assert.IsNotNull(lobbyModel.WarshipRatingScaleModel);
            Assert.IsNotNull(lobbyModel.RewardsThatHaveNotBeenShown);

            foreach (var warshipDto in lobbyModel.AccountDto.Warships)
            {
                Assert.IsNotNull(warshipDto.Description);
                Assert.IsNotNull(warshipDto.PrefabName);
                Assert.IsNotNull(warshipDto.CombatRoleName);
            }
        }
    }

    [TestFixture]
    internal sealed class LobbyModelFacadeServiceTests : BaseIntegrationFixture
    {
        /// <summary>
        /// Сервис создаст аккаунт с таким serviceId, если такого нет в БД,
        /// и вернёт заполненный LobbyModel
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ServiceCreatesAnAccountIfItIsNot()
        {
            //Arrange
            string serviceId = "someServiceId";
            //Act
            LobbyModel lobbyModel = await LobbyModelFacadeService.CreateAsync(serviceId);
            
            //Assert
            Assert.IsNotNull(lobbyModel);
            Assert.IsNotNull(lobbyModel.AccountDto);
            Assert.IsNotNull(lobbyModel.AccountDto.Warships);
            Assert.IsTrue(lobbyModel.AccountDto.Warships.Count>1);
            Assert.IsNotNull(lobbyModel.WarshipPowerScaleModel);
            Assert.IsNotNull(lobbyModel.WarshipRatingScaleModel);
            Assert.IsNotNull(lobbyModel.RewardsThatHaveNotBeenShown);

            foreach (var warshipDto in lobbyModel.AccountDto.Warships)
            {
                Assert.IsNotNull(warshipDto.Description);
                Assert.IsNotNull(warshipDto.PrefabName);
                Assert.IsNotNull(warshipDto.CombatRoleName);
            }
        }
        
        /// <summary>
        /// Сервис нормально прочитает аккаунт, который есть в БД, и отобразит в сериализуемый класс
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ServiceReadsAccountIfOneExists()
        {
            //Arrange
            AccountBuilder accountBuilder = new AccountBuilder(65184);
            AccountDirector accountDirector = new BigAccountDirector(accountBuilder, Context);
            accountDirector.WriteToDatabase();
            Account originalAccount = accountDirector.GetAccount();
            int originalAccountRating = accountDirector.GetAccountRating();
            int accountSoftCurrency = accountDirector.GetAccountSoftCurrency();
            int accountHardCurrency = accountDirector.GetAccountHardCurrency();
            //Act
            LobbyModel lobbyModel = await LobbyModelFacadeService.CreateAsync(originalAccount.ServiceId);
            
            //Assert
            Assert.AreEqual(originalAccountRating, lobbyModel.AccountDto.AccountRating);
            Assert.AreEqual(accountSoftCurrency, lobbyModel.AccountDto.SoftCurrency);
            Assert.AreEqual(accountHardCurrency, lobbyModel.AccountDto.HardCurrency);
            Assert.IsNotNull(lobbyModel);
            Assert.IsNotNull(lobbyModel.AccountDto);
            Assert.IsNotNull(lobbyModel.AccountDto.Warships);
            Assert.IsTrue(lobbyModel.AccountDto.Warships.Count>1);
            Assert.IsNotNull(lobbyModel.WarshipPowerScaleModel);
            Assert.IsNotNull(lobbyModel.WarshipRatingScaleModel);
            Assert.IsNotNull(lobbyModel.RewardsThatHaveNotBeenShown);

            foreach (var warshipDto in lobbyModel.AccountDto.Warships)
            {
                Assert.IsNotNull(warshipDto.Description);
                Assert.IsNotNull(warshipDto.PrefabName);
                Assert.IsNotNull(warshipDto.CombatRoleName);
            }
        }
    }
}