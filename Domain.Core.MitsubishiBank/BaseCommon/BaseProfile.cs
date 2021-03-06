﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.MitsubishiBank.CustomerCommon;

namespace Domain.Core.MitsubishiBank.BaseCommon
{
    public class BaseProfile
    {
        [Key, ForeignKey("Customer")]
        public Guid BaseProfileId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual Customer Customer { get; set; }
        public BaseProfile()
        {
            BaseProfileId = Guid.NewGuid();
        }
    }
}
