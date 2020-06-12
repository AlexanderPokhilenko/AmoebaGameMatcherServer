﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Tables
{
    public class LootboxDb
    {
        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }
        [Required] public int AccountId { get; set; }
        [Required] public LootboxType LootboxType { get; set; }
        [Required] public DateTime CreationDate { get; set; }
        [Required] public bool WasShown { get; set; }
        
        public Account Account { get; set; }
        
        
        public List<LootboxPrizeSoftCurrency> LootboxPrizeSoftCurrency { get ; set ; } = new List<LootboxPrizeSoftCurrency>();
        public List<LootboxPrizeHardCurrency> LootboxPrizeHardCurrency { get ; set ; } = new List<LootboxPrizeHardCurrency>();
        public List<LootboxPrizeSmallLootboxPoints> LootboxPrizePointsForSmallLootboxes { get; set;} = new List<LootboxPrizeSmallLootboxPoints>();
        public List<LootboxPrizeWarshipPowerPoints> LootboxPrizeWarshipPowerPoints{get;set;} = new List<LootboxPrizeWarshipPowerPoints>();
    }
}