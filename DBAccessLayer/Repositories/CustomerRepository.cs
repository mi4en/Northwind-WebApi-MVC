using DBAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccessLayer.Repositories
{
    public class CustomerRepository
    {
        public List<Customers> GetAllCustomers()
        {
            var customersList = new List<Customers>();

            using (var db = new NorthwindEntities())
            {
                try
                {
                    //var query = from c in db.Customers
                    //            orderby c.ContactName
                    //            select c;

                    //foreach (var customer in query)
                    //{
                    //    customersList.Add(customer);
                    //}
                    //return customersList;

                    return customersList = db.Customers.OrderBy(x => x.CustomerID).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Customers GetCustomerById(string id)
        {
            using (var db = new NorthwindEntities())
            {
                try
                {
                    //Customers customerRecord =
                    //(from customer in db.Customers
                    // where customer.CustomerID == id
                    // select customer).FirstOrDefault();

                    //return customerRecord;

                    return db.Customers.FirstOrDefault(c => c.CustomerID == id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<Orders> GetCustomerOrders(string id)
        {
            var ordersList = new List<Orders>();

            using (var db = new NorthwindEntities())
            {
                try
                {
                    var query = from o in db.Orders
                                orderby o.OrderID
                                where o.CustomerID == id
                                select o;

                    foreach (var order in query)
                    {
                        ordersList.Add(order);
                    }
                    return ordersList;
                   
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
