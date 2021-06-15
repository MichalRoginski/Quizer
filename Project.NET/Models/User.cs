using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.NET.Models
{
    public class User
    {
        [Display(Name = "Username:")]
        [Required]
        public string username { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        [Required]
        public string password { get; set; }
        public string GetHash(string password)
        {
            UInt64 hashedValue = 3074457345618258791ul;
            for (int i = 0; i < password.Length; i++)
            {
                hashedValue += password[i];
                hashedValue *= 3074457345618258799ul;
            }
            return hashedValue.ToString();
        }
    }
    
}
