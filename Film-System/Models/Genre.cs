using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmSystem.Models
{
    public class Genre
    {
        [Key]
        public int Id_genre { get; set; }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
    }
}
