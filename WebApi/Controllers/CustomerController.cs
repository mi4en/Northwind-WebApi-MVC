using ProjectFourthServices.Interfaces;
using WebApi.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;


namespace WebApi.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet, Route("customers")]
        public IList<CustomerModel> GetAllCustomers()
        {
            IList<CustomerModel> customerModel = new List<CustomerModel>();

            try
            {
                var customers = _customerService.GetAllCustomers();
                foreach (var customer in customers)
                {
                    customerModel.Add(new CustomerModel
                    {
                        CustomerID = customer.CustomerID,
                        CompanyName = customer.CompanyName,
                        ContactName = customer.ContactName,
                        ContactTitle = customer.ContactTitle,
                        Address = customer.Address,
                        City = customer.City,
                        Region = customer.Region,
                        PostalCode = customer.PostalCode,
                        Country = customer.Country,
                        Phone = customer.Phone,
                        Fax = customer.Fax
                    });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return customerModel;
        }

        [HttpGet, Route("customer/{id}")]
        public CustomerModel GetCustomerById(string id)
        {
            var customerModel = new CustomerModel();

            try
            {
                var customer = _customerService.GetCustomerById(id);
                customerModel = new CustomerModel
                {
                    CustomerID = customer.CustomerID,
                    CompanyName = customer.CompanyName,
                    ContactName = customer.ContactName,
                    ContactTitle = customer.ContactTitle,
                    Address = customer.Address,
                    City = customer.City,
                    Region = customer.Region,
                    PostalCode = customer.PostalCode,
                    Country = customer.Country,
                    Phone = customer.Phone,
                    Fax = customer.Fax
                };
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return customerModel;
        }

        [HttpGet, Route("customer/{id}/orders")]
        public IList<OrderModel> GetCustomerOrders(string id)
        {
            var customerModel = new CustomerModel();
            IList<OrderModel> orderModel = new List<OrderModel>();

            try
            {
                var orders = _customerService.GetCustomerOrders(id);
                foreach(var order in orders)
                {
                    orderModel.Add(new OrderModel
                    {
                        CustomerID = order.CustomerID,
                        OrderID = order.OrderID
                    });
                }
                return orderModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

    }
}
