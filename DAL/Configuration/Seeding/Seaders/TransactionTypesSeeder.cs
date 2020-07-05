﻿using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;
using DataLayer.Tables;

namespace AmoebaGameMatcherServer
{
    public class TransactionTypesSeeder
    {
        public void Seed(ApplicationDbContext dbContext)
        {
            if (!dbContext.TransactionTypes.Any())
            {
                var transactionTypes = new List<TransactionType>
                {
                    new TransactionType
                    {
                        Name = TransactionTypeEnum.Lootbox.ToString(), 
                        Id = TransactionTypeEnum.Lootbox
                    },
                    new TransactionType
                    {
                        Name = TransactionTypeEnum.LootboxSet.ToString(),
                        Id = TransactionTypeEnum.LootboxSet
                    },
                    new TransactionType
                    {
                        Name = TransactionTypeEnum.Warship.ToString(),
                        Id = TransactionTypeEnum.Warship
                    },
                    new TransactionType
                    {
                        Name = TransactionTypeEnum.WarshipAndSkin.ToString(),
                        Id = TransactionTypeEnum.WarshipAndSkin
                    },
                    new TransactionType
                    {
                        Name = TransactionTypeEnum.Skin.ToString(),
                        Id = TransactionTypeEnum.Skin
                    },
                    new TransactionType
                    {
                        Name = TransactionTypeEnum.WarshipPowerPoints.ToString(), 
                        Id = TransactionTypeEnum.WarshipPowerPoints
                    },
                    new TransactionType
                    {
                        Name = TransactionTypeEnum.DailyPrize.ToString(),
                        Id = TransactionTypeEnum.DailyPrize
                    },
                    new TransactionType
                    {
                        Name = TransactionTypeEnum.GameRegistration.ToString(), 
                        Id = TransactionTypeEnum.GameRegistration
                    },
                    new TransactionType
                    {
                        Name = TransactionTypeEnum.SoftCurrency.ToString(),
                        Id = TransactionTypeEnum.SoftCurrency
                    },
                    new TransactionType
                    {
                        Name = TransactionTypeEnum.HardCurrency.ToString(), 
                        Id = TransactionTypeEnum.HardCurrency
                    },
                    new TransactionType
                    {
                        Name = TransactionTypeEnum.WarshipLevel.ToString(),
                        Id = TransactionTypeEnum.WarshipLevel
                    },
                    
                    new TransactionType
                    {
                        Name = TransactionTypeEnum.MatchReward.ToString(),
                        Id = TransactionTypeEnum.MatchReward
                    }
                };
                dbContext.TransactionTypes.AddRange(transactionTypes);
                dbContext.SaveChanges();
            }
            
            if (dbContext.TransactionTypes.Count() != Enum.GetNames(typeof(TransactionTypeEnum)).Length)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}