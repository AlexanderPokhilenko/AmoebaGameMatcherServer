﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataLayer.Tables;

namespace DataLayer.Entities.Transactions.Decrement
{
    /// <summary>
    /// Описывает цену покупки.
    /// </summary>
    public class Decrement
    {
        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }
        [Required] public int TransactionId { get; set; }
        [Required] public int Amount {get;set; }
        [Required] public DecrementTypeEnum DecrementTypeId { get; set; }

        public int? WarshipId {get;set;}
        public Warship Warship { get; set; }
        public int? RealPurchaseModelId { get; set; }
        public RealPurchaseModel RealPurchaseModel { get; set; }
        
        public Transaction Transaction { get; set; }
        public DecrementType DecrementType { get; set; }
    }
}