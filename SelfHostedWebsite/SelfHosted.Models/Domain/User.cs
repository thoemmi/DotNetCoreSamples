using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SelfHosted.Models.Domain
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public string Firstname { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string BusinessUnit { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Firstname))
                return false;

            if (string.IsNullOrEmpty(LastName))
                return false;

            if (string.IsNullOrEmpty(Email))
                return false;

            return true;
        }
    }
}
