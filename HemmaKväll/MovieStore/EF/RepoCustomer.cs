using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStore.Models;
using System.Data.Entity;

namespace MovieStore.EF
{
    public class RepoCustomer 
    {
        MediaContext context;
        
        public RepoCustomer()
        {
            context = new MediaContext();
        }
        public IQueryable<Customer> GetAllCustomers()
        {
            var query = context.Customers.OrderBy(x => x.CustomerID).AsQueryable();
            return query;
        }
        public Customer GetCustomer(int id)
        {
            var customer = context.Customers.FirstOrDefault(x => x.CustomerID == id);
            return customer;
        }
        public Customer GetCustomerByName(string name)
        {
            
            var customer = context.Customers.FirstOrDefault(x => x.CustomerName == name);           
            return customer;
        }
        public IQueryable<Customer> GetAllRentedMovies()
        {
            var query = context.Customers.Include(x => x.RenteredMoviesCustomer).AsQueryable();
            return query;
        }
        public void CreateCustomer(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
        }
        public void UpdateCustomer(Customer customer)
        {
            var customerToUpdate = context.Customers.FirstOrDefault(x => x.CustomerID == customer.CustomerID);
            customerToUpdate.CustomerName = customer.CustomerName;
            customerToUpdate.CustomerAdress = customer.CustomerAdress;
            customerToUpdate.CustomerPhone = customer.CustomerPhone;
           

            //context.Entry(movie).State = EntityState.Modified;
            context.SaveChanges();
            //context.Entry(customer).State = EntityState.Modified;
        }
        public void DeleteCustomer(int id)
        {
            var customerToRemove = context.Customers.FirstOrDefault(x => x.CustomerID == id);
            context.Customers.Remove(customerToRemove);
            context.SaveChanges();

        }
    }
}
