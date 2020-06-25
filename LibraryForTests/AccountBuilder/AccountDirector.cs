﻿using System;
using System.Linq;
using DataLayer;
using DataLayer.Tables;

namespace LibraryForTests
{
    public abstract class AccountDirector
    {
        protected readonly AccountBuilder Builder;
        private readonly ApplicationDbContext dbContext;

        protected AccountDirector(AccountBuilder builder, ApplicationDbContext dbContext)
        {
            Builder = builder;
            this.dbContext = dbContext;
        }

        public void WriteToDatabase()
        {
            string username = "username_" + DateTime.Now.ToLongTimeString();
            string serviceId = "serviceId_" + DateTime.Now.ToLongTimeString();
            Builder.SetBaseInfo(username, serviceId, DateTime.Now);
            ConstructWarships();
            Account account = Builder.GetAccount();
            dbContext.Accounts.Add(account);
            dbContext.SaveChanges();
            ConstructLootboxes();
            dbContext.SaveChanges();
        }
        
        protected abstract void ConstructWarships();
        protected abstract void ConstructLootboxes();

        public Account GetAccount()
        {
            return Builder.GetAccount();
        }
        
        public int GetAccountRating()
        {
            // return Builder.GetAccount().Warships
            //            .SelectMany(warship => warship.BattleRoyaleMatchResults)
            //            .Sum(matchResult => matchResult.WarshipRatingDelta);
            throw new Exception();
        }

        public int GetAccountSoftCurrency()
        {
            throw new Exception();
            // int fromMatches = Builder.GetAccount().Warships
            //     .SelectMany(warship => warship.BattleRoyaleMatchResults)
            //     .Sum(matchResult => matchResult.SoftCurrencyDelta);
            //
            // Console.WriteLine($"{nameof(fromMatches)} {fromMatches}");
            // int fromLootboxes = 0;
            //     // Builder.GetAccount().Lootboxes
            //     // .SelectMany(lootbox => lootbox.LootboxPrizeSoftCurrency)
            //     // .Sum(prize => prize.Quantity);
            //
            // Console.WriteLine($"{nameof(fromLootboxes)} {fromLootboxes}");
            // //TODO посчитать покупки за реальную валюту
            // return fromMatches + fromLootboxes;
        }
        
        public int GetAccountHardCurrency()
        {
            //TODO посчитать лутбоксы
            //TODO посчитать покупки за реальную валюту
            return 0;
        }

        public int GetNotShownSoftCurrency()
        {
            throw new Exception();
            // int fromMatches = Builder.GetAccount().Warships
            //     .SelectMany(warship => warship.BattleRoyaleMatchResults)
            //     .Where( matchResult=> !matchResult.WasShown )
            //     .Sum(matchResult => matchResult.SoftCurrencyDelta);
            // int fromLootboxes = 0;
            // // int fromLootboxes = Builder.GetAccount().Lootboxes
            // //     .Where( lootbox=> !lootbox.WasShown )
            // //     .SelectMany(lootbox => lootbox.LootboxPrizeSoftCurrency)
            // //     .Sum(prize => prize.Quantity);
            //
            // Console.WriteLine($"{nameof(fromMatches)} {fromMatches} {nameof(fromLootboxes)} {fromLootboxes}");
            // return fromMatches + fromLootboxes;
        }
        
        public int GetNotShownHardCurrency()
        {
            int fromLootboxes = 0;
            // int fromLootboxes = Builder.GetAccount().Lootboxes
            //     .Where( lootbox=> !lootbox.WasShown )
            //     .SelectMany(lootbox => lootbox.LootboxPrizeHardCurrency)
            //     .Sum(prize => prize.Quantity);
            
            return fromLootboxes;
        }
        
        public int GetNotShownSmallLootboxPoints()
        {
            throw new Exception();
            // int fromMatches = Builder.GetAccount().Warships
            //     .SelectMany(warship => warship.BattleRoyaleMatchResults)
            //     .Where( matchResult=> !matchResult.WasShown )
            //     .Sum(matchResult => matchResult.SmallLootboxPoints);
            
            //
            // int fromLootboxes = 0;
            // // int fromLootboxes = Builder.GetAccount().Lootboxes
            // //     .Where( lootbox=> !lootbox.WasShown )
            // //     .SelectMany(lootbox => lootbox.LootboxPrizePointsForSmallLootboxes)
            // //     .Sum(prize => prize.Quantity);
            //
            // return fromMatches+fromLootboxes;
        }

        public int GetNotShownAccountRating()
        {
            throw new Exception();
            // return Builder.GetAccount().Warships
            //     .SelectMany(warship => warship.BattleRoyaleMatchResults)
            //     .Where(matchResult => matchResult.IsFinished && !matchResult.WasShown)
            //     .Sum(matchResult => matchResult.WarshipRatingDelta);
        }
    }
}