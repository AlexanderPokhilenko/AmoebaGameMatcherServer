﻿using System.Threading.Tasks;
using DataLayer.Tables;
using JetBrains.Annotations;
using Npgsql;

namespace AmoebaGameMatcherServer.Services.LobbyInitialization
{
    /// <summary>
    /// Во время загрузки данных в лобби достаёт аккаунт из БД.
    /// Если такого аккаунта нет, то вернёт null.
    /// </summary>
    public class AccountDbReaderService
    {
        private readonly DbAccountWarshipsReader dbAccountWarshipsReader;
        private readonly AccountResourcesDbReader accountResourcesDbReader;

        public AccountDbReaderService(NpgsqlConnection connection)
        {
            dbAccountWarshipsReader = new DbAccountWarshipsReader(connection);
            accountResourcesDbReader = new AccountResourcesDbReader(connection);
        }

        /// <summary>
        /// Отвечает за получение данных про аккаунт из БД.
        /// </summary>
        [ItemCanBeNull]
        public async Task<Account> GetAccount([NotNull] string serviceId)
        {
            Account account = await dbAccountWarshipsReader.GetAccountWithWarships(serviceId);
            var accountResources = await accountResourcesDbReader.GetAccountResources(serviceId);
            
            account.HardCurrency = accountResources.HardCurrency;
            account.SoftCurrency = accountResources.SoftCurrency;
            account.SmallLootboxPoints = accountResources.SmallLootboxPoints;
            return account;
        }
    }
}