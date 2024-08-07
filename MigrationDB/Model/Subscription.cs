﻿using CommonLibrary.CommonModels;
using Microsoft.EntityFrameworkCore;
using MigrationDB.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MigrationDB.Model
{
    [Table("Subscription")]
    public class Subscription : BaseModel
    {
        public Experts Experts { get; set; }
        public Guid ExpertsId { get; set; }
        public string? ImagePath { get; set; }
        public string? Tag { get; set; }
        public string? ServiceType { get; set; }
        public string? PlanType { get; set; }
        public string? ChatId { get; set; }
        public int?  DurationMonth { get; set; }
        [Precision(18, 2)]
        public decimal?  Amount { get; set; }
        public string?  PremiumTelegramLink { get; set; }
        public string?  Description { get; set; }
        public int? DiscountPercentage { get; set; } 
        public DateTime? DiscountValidFrom { get; set; }
        public DateTime? DiscountValidTo { get; set; }
        public bool? IsSpecialSubscription { get; set; }
        public bool? isCustom { get; set; }
        public bool isActive { get; set; }
    }
}
