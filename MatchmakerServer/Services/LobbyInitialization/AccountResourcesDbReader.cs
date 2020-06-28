﻿using System.Threading.Tasks;
using Dapper;
using JetBrains.Annotations;
using Npgsql;

namespace AmoebaGameMatcherServer.Services.LobbyInitialization
{
    /// <summary>
    /// Достаёт из БД данные про кол-во ресурсов у аккаунта
    /// </summary>
    public class AccountResourcesDbReader
    {
        private readonly string sqlSelectAccountResourcesInfo = $@"
select        
(
    coalesce((select sum(I.""Amount"") 
      from ""Accounts"" A
        join ""Transactions"" O on A.""Id"" = O.""AccountId""
        join ""Resources"" P on O.""Id"" = P.""TransactionId""
        join ""Increments""  I on P.""Id"" = I.""ResourceId""
        join ""IncrementTypes"" IT on I.""IncrementTypeId"" = IT.""Id""    
        where A.""ServiceId"" = @serviceIdPar and it.""Name"" = 'SoftCurrency'
        
        ), 0)
    
    -
 coalesce((select sum(D.""Amount"")
    from ""Accounts"" A
        join ""Transactions"" O on A.""Id"" = O.""AccountId""
        join ""Resources"" P on O.""Id"" = P.""TransactionId""
        join ""Decrements""  D on P.""Id"" = D.""ResourceId""
        join ""DecrementTypes"" DT on D.""DecrementTypeId"" = DT.""Id""
           where A.""ServiceId"" = @serviceIdPar and DT.""Name"" = 'SoftCurrency'
    ), 0)

    
    ) as ""SoftCurrency"",

(coalesce((select sum(I.""Amount"")
    from ""Accounts"" A
        join ""Transactions"" T on A.""Id"" = T.""AccountId""
        join ""Resources"" R on T.""Id"" = R.""TransactionId""
        join ""Increments""  I on R.""Id"" = I.""ResourceId""
        join ""IncrementTypes"" IT on I.""IncrementTypeId"" = IT.""Id""
           where A.""ServiceId"" = @serviceIdPar and it.""Name"" = 'HardCurrency'
    ),0)
    -
    coalesce((select sum(D.""Amount"")
    from ""Accounts"" A
         join ""Transactions"" T on A.""Id"" = T.""AccountId""
         join ""Resources"" R on T.""Id"" = R.""TransactionId""
        join ""Decrements""  D on R.""Id"" = D.""ResourceId""
         join ""DecrementTypes"" DT on D.""DecrementTypeId"" = DT.""Id""
              where A.""ServiceId"" = @serviceIdPar and DT.""Name"" = 'HardCurrency'
    ),0)) as ""HardCurrency"",
    

 (coalesce(
         (select sum(I.""Amount"")
          from ""Accounts"" A
           join ""Transactions"" T on A.""Id"" = T.""AccountId""
           join ""Resources"" R on T.""Id"" = R.""TransactionId""
           join ""Increments""  I on R.""Id"" = I.""ResourceId""
           join ""IncrementTypes"" IT on I.""IncrementTypeId"" = IT.""Id""
          where A.""ServiceId"" = @serviceIdPar and it.""Name"" = 'LootboxPoints'
         )
     , 0) 
     -
  coalesce(
          (select sum(D.""Amount"")
           from ""Accounts"" A
                join ""Transactions"" T on A.""Id"" = T.""AccountId""
                join ""Resources"" R on T.""Id"" = R.""TransactionId""
                join ""Decrements"" D on R.""Id"" = D.""ResourceId""
                join ""DecrementTypes"" DT on D.""DecrementTypeId"" = DT.""Id""
           where A.""ServiceId"" = @serviceIdPar and DT.""Name"" = 'LootboxPoints'
        
          )
      , 0))
     as ""LootboxPoints""
;



        ";

        private readonly NpgsqlConnection connection;

        public AccountResourcesDbReader(NpgsqlConnection connection)
        {
            this.connection = connection;
        }
        
        public async Task<DapperHelperAccountResources> GetAccountResourcesAsync([NotNull] string serviceId)
        {
            var parameters = new {serviceIdPar = serviceId};
            var accountResources = await connection
                .QuerySingleAsync<DapperHelperAccountResources>(sqlSelectAccountResourcesInfo, parameters);

            return accountResources;
        }
    }
}