using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmSystem.Models
{
    public class MovieRating
    {
        [Key]
        public int Id_movieRating { get; set; }

        [ForeignKey("Movie")]
        public int Fk_movie { get; set; }
        public virtual Movie Movie { get; set; }

        [ForeignKey("Person")]
        public int Fk_person { get; set; }
        public virtual Person Person { get; set; }

        [Required]
        public int Rating { get; set; }
    }
}
