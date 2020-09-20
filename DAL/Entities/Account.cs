﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using DataLayer.Entities.Transactions.Decrement;

namespace DataLayer.Tables
{
    public class Account
    {
        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }
        [Required] public string ServiceId { get; set; }
        [Required] public string Username { get; set; }
        [Required] public DateTime RegistrationDateTime { get; set; }
    
        public List<Warship> Warships { get; set; } = new List<Warship>();
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
        public List<ShopModelDb> ShopModels { get; set; } = new List<ShopModelDb>();
        public List<RealPurchaseModel> RealPurchaseModels { get; set; } = new List<RealPurchaseModel>();
        
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"{GetType().Name} ");
            stringBuilder.Append($"{nameof(Id)} {Id} ");
            stringBuilder.Append($"{nameof(ServiceId)} {ServiceId} ");
            stringBuilder.Append($"{nameof(RegistrationDateTime)} {RegistrationDateTime} ");
            stringBuilder.Append($"warshipsCount {Warships?.Count} ");
            return stringBuilder.ToString();
        }
    }

    
}