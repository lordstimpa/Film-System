using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmSystem.Models
{
    public class PersonGenre
    {
        [Key]
        public int Id_personGenre { get; set; }

        [ForeignKey("Person")]
        public int Fk_person { get; set; }
        public virtual Person Person { get; set; }

        [ForeignKey("Genre")]
        public int Fk_genre { get; set; }
        public virtual Genre Genre { get; set; }
    }
}