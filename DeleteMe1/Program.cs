﻿using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using DataLayer;
using DataLayer.Tables;
using Npgsql;

namespace DeleteMe1
{
    public class Program
    {
        static void Main()
        {
            string databaseName = "DapperTests6";    
            string connectionString = DbConfigIgnore.GetConnectionString(databaseName);
            ApplicationDbContext dbContext = new DbContextFactory().Create(databaseName);

            DbWork dbWork = new DbWork(dbContext);
            // dbWork.TryInsert();
            string serviceId = dbWork.GetSomeServiceId();
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                // var parameters = new { serviceDichId = serviceId};

                string sql1 = @"select   a.*, w.*, wt.*
	                                from accounts a
	                                inner join warships w on a.id = w.account_id 
	                                inner join warship_types wt on w.warship_type_id = wt.id
                ";
                
                Dictionary<int, Account> lookup = new Dictionary<int, Account>();
                
                // IQueryable<Account> accounts = connection
                //     .Query<Account, Warship, Account>(sql1, (a, w) =>
                //     {
                //         if (!lookup.TryGetValue(a.Id, out Account account)) 
                //         {
                //             lookup.Add(a.Id, account = a);
                //         }
                //
                //         if (account.Warships == null)
                //         {
                //             account.Warships = new List<Warship>();
                //         } 
                //         
                //         account.Warships.Add(w);
                //         return account;
                //     }).AsQueryable();

                int index = 0;
                var accounts2 = connection
                    .Query<Account, Warship, WarshipType,  Account>(sql1, (a, w, wt) =>
                    {
                        index++;
                        Console.WriteLine($"index {index} "+a);
                        Console.WriteLine($"\t\tindex {index} "+w);
                        Console.WriteLine($"\t\t\t\tindex {index} "+wt);
                        return null;
                    }).AsQueryable();
            }
        }
    }
}