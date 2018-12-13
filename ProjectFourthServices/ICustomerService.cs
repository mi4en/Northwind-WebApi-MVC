using DBAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFourthServices.Interfaces
{
    public interface ICustomerService
    {
        IList<Customers> GetAllCustomers();
        Customers GetCustomerById(string id);
        IList<Orders> GetCustomerOrders(string id);
    }
}
