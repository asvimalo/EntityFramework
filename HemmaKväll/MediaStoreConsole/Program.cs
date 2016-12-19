using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStore.EF;
using MovieStore.Models;

namespace MediaStoreConsole
{
    class Program
    {
        
        static void Main(string[] args)
        {
            GetCustomers();
        }
        public static void GetCustomers()
        {
            RepoCustomer repoCust = new RepoCustomer();
            var customers = repoCust.GetCustomer();
            foreach (var customer in customers)
            {
                Console.WriteLine($"CustomerID: {customer.CustomerID}");
                Console.WriteLine($"Customer Name: {customer.CustomerName}");
                foreach (var renteresMovie in customer.RenteredMoviesCustomer)
                {
                    Console.WriteLine($"CustomerID: {renteresMovie.Customer}"); 
                }

            }
            Console.ReadKey();
        }
    }
}
