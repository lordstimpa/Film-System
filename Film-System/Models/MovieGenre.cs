using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmSystem.Models
{
    public class MovieGenre
    {
        [Key]
        public int Id_movieGenre { get; set; }

        [ForeignKey("Movie")]
        public int Fk_movie { get; set; }
        public virtual Movie Movie { get; set; }

        [ForeignKey("Genre")]
        public int Fk_genre { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
