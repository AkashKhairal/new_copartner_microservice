﻿namespace ExpertsService.Dtos
{
    public class RAListingDetailsReadDto
    {
        public DateTime JoinDate { get; set; }
        public string Name { get; set; }
        public string SEBINo { get; set; }
        public int? FixCommission { get; set; }
        public long RAEarning { get; set; }
    }
}