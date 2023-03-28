using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_Schad.Interfaces;
using Test_Schad.Models;
using Test_Schand.Services;

namespace Test_Schad.Controllers
{
    public class CustomeTypeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public CustomeTypeController( IConfiguration config)
        {
            //_logger = logger;
            _configuration = config;
        }
        public ActionResult Index()
        {
            ITypeCustome t = new TipoClienteService(_configuration);

             var result = t.getCustomeType();

            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            ITypeCustome t = new TipoClienteService(_configuration);

            var result = t.getCustomeType(id);

            return View("Create",result);
        
        }


        [HttpPost]
        public IActionResult ProceseCustomeType()
        {
            CustomerType customerType = new CustomerType();

            customerType.Description = Request.Form["Description"].ToString();
            
            ITypeCustome t = new TipoClienteService(_configuration);
            var result = t.setAddCustomeType(customerType);

            return View("Index");
        }

        public IActionResult Delete(int id)
        {
            ITypeCustome t = new TipoClienteService(_configuration);

            var result = t.setDeleteCustomeType(id);
            return View("Index", result);
        }


    }
}
