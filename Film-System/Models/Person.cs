using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmSystem.Models
{
    public class Person
    {
        [Key]
        public int Id_person { get; set; }

        [Required]
        [MaxLength(30)]
        public string First_name { get; set; }

        [Required]
        [MaxLength(30)]
        public string Last_name { get; set; }

        [Required]
        [MaxLength(254)]
        public string Email { get; set; }
    }
}
