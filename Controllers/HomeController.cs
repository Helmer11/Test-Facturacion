using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        ICustome _custome;
        ITypeCustome typeCust;
        Customer customer;

        public HomeController(ILogger<HomeController> logger, IConfiguration  config)
        {
            _logger = logger;
            _configuration = config;
           _custome = new ClienteService(_configuration);
            typeCust = new TipoClienteService(_configuration);
            customer = new Customer();
        }

        public IActionResult Index()
        {
            object lista = null ;
            if (ModelState.IsValid)
            {
                lista = _custome.getCustome();  
            }
            return View(lista);
        }
        public IActionResult Create()
        {
            
            var result = typeCust.getCustomeType();
            List<SelectListItem> lista = new List<SelectListItem>()
                {
                    new SelectListItem { 
                        Text = result.FirstOrDefault().Description, 
                        Value= result.FirstOrDefault().Id.ToString()
                    }
                };
            ViewBag.CustomeType = lista;

            return View();
        }


        [HttpPost]
        public IActionResult ProceseCustome(IFormCollection form)
        {
            

            customer.CustName = form["CustName"].ToString() ;
            customer.Adress = form["Adress"].ToString();
            customer.CustomerTypeId = Convert.ToInt32(form["customeTypeId"]);
            ICustome c = new ClienteService(_configuration);
             var result = c.setAddCustome(customer);
            return View("index");
        }
 
        public IActionResult Delete(int id)
        {
            ICustome c = new ClienteService(_configuration);
            var result = c.setDeleteCustome(id);
            return View();
        }



    }
}