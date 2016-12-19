using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Models
{
    public class RentedMovies
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RentedID { get; set; }
        public int CustomerID { get; set; }
        public int MovieID { get; set; }
        public System.DateTime RentedTo { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
        [ForeignKey("MovieID")]
        public virtual Movie Movie { get; set; }
        public RentedMovies()
        {
            
        }
        public RentedMovies(int customerID, int movieID, DateTime rentedTo)
        {
            CustomerID = customerID;
            MovieID = movieID;
            RentedTo = rentedTo;
        }
        public RentedMovies(int rentedID, int customerID, int movieID, DateTime rentedTo)
        {
            RentedID = rentedID;
            CustomerID = customerID;
            MovieID = movieID;
            RentedTo = rentedTo;
        }
    }
}
