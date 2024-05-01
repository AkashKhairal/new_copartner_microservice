﻿namespace AffiliatePartnerService.Dtos
{
    public class AffiliatePartnerReadDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? AffiliatePartnerImagePath { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public string GST { get; set; }
        public string PAN { get; set; }
        public string ReferralCode { get; set; }
    }
}