﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReWork.DataProvider.Entities
{
    [Table("CustomerProfiles")]
    public class CustomerProfile
    {
        [Key]
        [ForeignKey("User")]
        public string Id { get; set; }

        [Required]
        public virtual User User { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
