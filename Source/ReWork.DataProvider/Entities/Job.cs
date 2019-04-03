﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReWork.DataProvider.Entities
{
    [Table("Jobs")]
    public class Job
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength:70, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(maximumLength: 250, MinimumLength = 3)]
        public string Description { get; set; }

        [Range(0,Int32.MaxValue)]
        public int? Price { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [ForeignKey("Customer")]
        public string CustomerId { get; set; }

        [Required]
        public virtual CustomerProfile Customer { get; set; }

        [ForeignKey("Employee")]
        public string EmployeeId { get; set; }

        public virtual EmployeeProfile Employee { get; set; }


        
        public virtual ICollection<Offer> Offers{ get; set; }
   
        public virtual FeedBack FeedBack { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }
    }
}
