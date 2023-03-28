using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Test_Schad.Interfaces;
using Test_Schad.Models;
using Test_Schand.Services;

namespace Test_Schad.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        

        public HomeController(ILogger<HomeController> logger, IConfiguration  config)
        {
            _logger = logger;
            _configuration = config;
        }

        public IActionResult Index()
        {
            if (ModelState.IsValid)
            {

            }

            ICustome c = new ClienteService(_configuration);

            var lista = c.getCustome();

            return View(lista);
        }
        public IActionResult Create()
        {
            ITypeCustome typeCust = new TipoClienteService(_configuration);
                var result = typeCust.getCustomeType();
                ViewBag.CustomeType = result;

            return View();
        }


        [HttpPost]
        public IActionResult ProceseCustome(IFormCollection form)
        {
            Customer customer = new Customer();

            customer.CustName = form["CustName"].ToString() ;
            customer.Adress = Request.Form["Adress"].ToString();
            customer.CustomerTypeId = Convert.ToInt32(Request.Form["customeTypeId"]);
            ICustome c = new ClienteService(_configuration);
             var result = c.setAddCustome(customer);
               
            return View("index");
        }
 
    }
}