﻿using System.ComponentModel.DataAnnotations;

namespace DataLayer.Tables
{
    public class IncrementType
    {
        [Key] public IncrementTypeEnum Id { get; set; }
        [Required] public string Name { get; set; }
    }
}