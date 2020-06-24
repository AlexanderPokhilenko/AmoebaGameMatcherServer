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

        [ItemCanBeNull]
        public async Task<AccountDbDto> ReadAccountAsync([NotNull] string serviceId)
        {
            AccountDbDto account = await dbAccountWarshipsReader.GetAccountWithWarshipsAsync(serviceId);
            if (account == null)
            {
                return null;
            }
            
            var accountResources = await accountResourcesDbReader.GetAccountResourcesAsync(serviceId);
            account.HardCurrency = accountResources.HardCurrency;
            account.SoftCurrency = accountResources.SoftCurrency;
            account.LootboxPoints = accountResources.LootboxPoints;
            return account;
        }
    }
}