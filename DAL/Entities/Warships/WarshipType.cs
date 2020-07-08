﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Tables
{
    public class WarshipType
    {
        [Key] public WarshipTypeEnum Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Description { get; set; }
        [Required] public WarshipCombatRoleEnum WarshipCombatRoleId { get; set; }
        
        public WarshipCombatRole WarshipCombatRole { get; set; }

        public IEnumerable<Warship> Warships { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"{GetType().Name} ");
            stringBuilder.Append($"{nameof(Id)} {Id} ");
            stringBuilder.Append($"{nameof(Name)} {Name} ");
            stringBuilder.Append($"{nameof(Description)} {Description} ");
            stringBuilder.Append($"{nameof(WarshipCombatRoleId)} {WarshipCombatRoleId} ");
            return stringBuilder.ToString();
        }
    }

    public enum SkinTypeEnum
    {
        Hare=1,
        Bird=2,
        Smiley=3,
        HareDestroyer=4
    }
    
    public class SkinType
    {
        [Key] public SkinTypeEnum Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public WarshipTypeEnum WarshipTypeId { get; set; }
    }
}