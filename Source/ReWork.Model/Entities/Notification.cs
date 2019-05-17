﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReWork.Model.Entities
{
    [Table("Notifications")]
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100,MinimumLength = 10)]
        public string Text { get; set; }

        [Required]
        public DateTime? AddedDate { get; set; }

        [ForeignKey("Sender")]
        public string SenderId { get; set; }

        public User Sender { get; set; }

        [ForeignKey("Reciver")]
        public string ReciverId { get; set; }

        [Required]
        public User Reciver { get; set; }
    }
}