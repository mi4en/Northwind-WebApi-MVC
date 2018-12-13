using DBAccessLayer.Models;
using ProjectFourthServices.Interfaces;
using DBAccessLayer.Repositories;
using System.Collections.Generic;

namespace ProjectFourthServices.Classes
{
    public class CustomerService : ICustomerService
    {
        public IList<Customers> GetAllCustomers()
        {
            var customerRepo = new CustomerRepository();
            return customerRepo.GetAllCustomers();
        }

        public Customers GetCustomerById(string id)
        {
            var customerRepo = new CustomerRepository();
            return customerRepo.GetCustomerById(id);
        }

        public IList<Orders> GetCustomerOrders(string id)
        {
            var customerRepo = new CustomerRepository();
            return customerRepo.GetCustomerOrders(id);
        }
    }
}
