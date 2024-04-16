﻿using MigrationDB.Model;
using MigrationDB.Models;

namespace SubscriptionService.Dtos
{
    public class SubscriberReadDto
    {
        public Guid Id { get; set; }
        
        public Guid SubscriptionId { get; set; }


        public Guid UserId { get; set; }

        public decimal GSTAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMode { get; set; }
        public bool isActive { get; set; }
    }
}