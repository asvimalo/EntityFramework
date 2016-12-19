using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Models
{
    [Table("Movie")]
    public class Movie
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }
        [StringLength(50)]
        public string MovieName { get; set; }
        [StringLength(50)]
        public string DirectorName { get; set; }
        public Nullable<DateTime> ReleaseDate { get; set; }
        public Nullable<int> GenreID { get; set; }

        [ForeignKey("GenreID")]
        public virtual Genre Genre { get; set; }

        public virtual ICollection<RentedMovies> RenteredMovies { get; set; }
        public Movie()
        {
            RenteredMovies = new HashSet<RentedMovies>();
        }
        public Movie(string movieName, string directorName, DateTime releasedDate, int genreID)
        {
            MovieName = movieName;
            DirectorName = directorName;
            ReleaseDate = releasedDate;
            GenreID = genreID;

        }
        public Movie(int id, string movieName, string directorName, DateTime releasedDate, int genreID)
        {
            MovieId = id;
            MovieName = movieName;
            DirectorName = directorName;
            ReleaseDate = releasedDate;
            GenreID = genreID;

        }
    }
}
