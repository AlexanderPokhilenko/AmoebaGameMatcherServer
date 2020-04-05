﻿using System.Threading.Tasks;
using DataLayer;
using DataLayer.Tables;
using MatchmakerTest.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchmakerTest.Experimental
{
    [TestClass]
    public class LazyLoadingTests
    {
        [TestMethod]
        public async Task Test1()
        {
            //Arrange
            ApplicationDbContext dbContext = new InMemoryDbContextFactory("sich").Create();
            Account account = TestsAccountFactory.CreateUniqueAccount();
            await dbContext.Accounts.AddAsync(account);
            await dbContext.SaveChangesAsync();
            
            //Act
            Account accountDb = await dbContext.Accounts
                .SingleOrDefaultAsync(account1 => account1.Id == account.Id);
            
            //Assert
            Assert.IsNotNull(accountDb);
            CollectionAssert.AreEqual(account.Warships, accountDb.Warships);            
            
        }
    }
}