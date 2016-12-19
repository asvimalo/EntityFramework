using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Models
{
    public class Genre
    {
       

        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GenreID { get; set; }

        [StringLength(50)]
        public string GenreName { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
        public Genre()
        {
            this.Movies = new HashSet<Movie>();
        }
    }
}
