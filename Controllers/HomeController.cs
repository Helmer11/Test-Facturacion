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
        

        public HomeController(ILogger<HomeController> logger, IConfiguration  config)
        {
            _logger = logger;
            _configuration = config;
        }

        public IActionResult Index()
        {
            object lista = null ;
            if (ModelState.IsValid)
            {
                ICustome c = new ClienteService(_configuration);
                lista = c.getCustome();  
            }
            return View(lista);
        }
        public IActionResult Create()
        {
            ITypeCustome typeCust = new TipoClienteService(_configuration);
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
            Customer customer = new Customer();

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