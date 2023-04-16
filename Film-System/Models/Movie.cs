using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmSystem.Models
{
    public class Movie
    {
        [Key]
        public int Id_movielink { get; set; }

        [ForeignKey("Person")]
        public int Fk_person { get; set; }
        public virtual Person Person { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(2048)]
        public string Link { get; set; }

    }
}
