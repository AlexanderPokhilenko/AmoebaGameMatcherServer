﻿using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using NetworkLibrary.NetworkLibrary.Http;

namespace AmoebaGameMatcherServer.Services.LobbyInitialization
{
    /// <summary>
    /// Нужен для получения данных про аккаунт из БД при инициализации лобби.
    /// Если такого аккаунта нет в БД, то попытается создать его.
    /// Аккаунт не будет создан, если ServiceId не действителен.
    /// </summary>
    public class AccountFacadeService
    {
        private readonly AccountDbReaderService accountDbReaderService;
        private readonly AccountRegistrationService accountRegistrationService;

        public AccountFacadeService(AccountDbReaderService accountDbReaderService,
            AccountRegistrationService accountRegistrationService)
        {
            this.accountDbReaderService = accountDbReaderService;
            this.accountRegistrationService = accountRegistrationService;
        }
        
        [ItemCanBeNull]
        public async Task<RelevantAccountData> GetOrCreateAccountData([NotNull] string serviceId)
        {
            RelevantAccountData accountInfo = await accountDbReaderService.GetAccountInfo(serviceId);
            
            if (accountInfo == null)
            {
                Console.WriteLine("Попытка создать аккаунт");
                if (await accountRegistrationService.TryRegisterAccount(serviceId))
                {
                    Console.WriteLine("Успешная регистрация");
                    accountInfo = await accountDbReaderService.GetAccountInfo(serviceId);
                }
                else
                {
                    Console.WriteLine("Не удалось выполнить регистрацию аккаунта");
                    return null;
                }
            }

            return accountInfo;
        }
    }
}