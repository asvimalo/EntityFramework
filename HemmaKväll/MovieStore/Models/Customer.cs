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
    [Table("Customer")]
    public class Customer
    {
        
        public Customer()
        {
            RenteredMoviesCustomer = new HashSet<RentedMovies>();
        }
        public Customer(string custName, string custAddress, string phone)
        {
            CustomerName = custName;
            CustomerAdress = custAddress;
            CustomerPhone = phone;
        }
        public Customer(int customerID, string custName, string custAddress, string phone)
        {
            CustomerID = customerID;
            CustomerName = custName;
            CustomerAdress = custAddress;
            CustomerPhone = phone;
        }
        [Key,Required,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }
        [StringLength(50)]
        public string CustomerName { get; set; }
        [StringLength(50)]
        public string CustomerAdress { get; set; }
        [StringLength(50)]
        public string CustomerPhone { get; set; }
        public virtual ICollection<RentedMovies> RenteredMoviesCustomer { get; set; }
    }
}
