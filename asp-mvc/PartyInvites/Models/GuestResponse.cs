﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Please, enter your name.")]
        public string Name { get; set; }
        [Required(ErrorMessage="Please, enter your email.")]
        [RegularExpression(".+\\@.+\\..", ErrorMessage = "Please enter valid email adress.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please, enter your phone.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please, specify whether your'll attended.")]
        public bool? WillAttended { get; set; }

    }
}