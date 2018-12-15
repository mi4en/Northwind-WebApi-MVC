using Newtonsoft.Json;
using ProjectFourthMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProjectFourthMVC.Controllers
{
    public class HomeController : Controller
    {
        //Hosted web API REST Service base url  
        private readonly string baseUrl = "http://localhost:8090/";

        public async Task<ActionResult> Index()
        {
            IEnumerable<CustomerViewModel> customerList = new List<CustomerViewModel>();

            using(var client = new HttpClient())
            {
                try
                {
                    //Passing service base url  
                    client.BaseAddress = new Uri(baseUrl);

                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = await client.GetAsync("customers");

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        customerList = JsonConvert.DeserializeObject<List<CustomerViewModel>>(EmpResponse);

                    }
                    else //send error
                    {
                        //log response status here..

                        customerList = Enumerable.Empty<CustomerViewModel>();

                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                    //returning the employee list to view  
                    //return View(getCustomerList.Where(x => x.ContactName.Contains(searching) || searching == null));
                    return View(customerList);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<ActionResult> IndexSearch(string searchTerm)
        {
            IEnumerable<CustomerViewModel> customerList = new List<CustomerViewModel>();

            using (var client = new HttpClient())
            {
                try
                {
                    //Passing service base url  
                    client.BaseAddress = new Uri(baseUrl);

                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Sending request to find web api REST service resource GetAllCustomers using HttpClient  
                    HttpResponseMessage Res = await client.GetAsync("customers");

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        customerList = JsonConvert.DeserializeObject<List<CustomerViewModel>>(EmpResponse);

                    }
                    else //send error
                    {
                        //log response status here..

                        customerList = Enumerable.Empty<CustomerViewModel>();

                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                    //returning the filtered employee list to view  
                    return View(customerList.Where(x => x.ContactName.Contains(searchTerm)));                 
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<ActionResult> Details(string id)
        {
            CustomerViewModel customer = new CustomerViewModel();

            using (var client = new HttpClient())
            {
                try
                {
                    //Passing service base url  
                    client.BaseAddress = new Uri(baseUrl);

                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Sending request to find web api REST service resource GetCustomerById using HttpClient  
                    HttpResponseMessage Res = await client.GetAsync("customer/" + id);

                    //Checking the response is successful or not which is sent using HttpClient  
                
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into our var  
                        customer = JsonConvert.DeserializeObject<CustomerViewModel>(EmpResponse);

                    }
                    else //send error
                    {
                        //log response status here..

                        customer = null;

                        ModelState.AddModelError(string.Empty, "User Not Found");
                    }
                    //returning the employee list to view  
                    return View(customer);
                }
                catch(Exception ex)
                {
                  throw ex;
                }
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}