﻿using CommonLibrary.CommonModels;
using MigrationDB.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseService.Models
{
    [Table("Course")]
    public class Course : BaseModel
    {
        [Required]
        public string CourseName { get; set; }
        public int VideoCount { get; set; }
        public DateTime Duration { get; set; }
        public DateTime LaunchDate { get; set; }
        public Experts Experts { get; set; }
        public Guid ExpertId { get; set; }
        public int Amount { get; set; }
    }
}
