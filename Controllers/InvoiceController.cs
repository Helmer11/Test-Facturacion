using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_Schad.Interfaces;
using Test_Schad.Models;
using Test_Schad.Services;

namespace Test_Schad.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IConfiguration configuration;
        IInvoice _fact;

        public InvoiceController(IConfiguration _configuration)
        {
            configuration = _configuration;
            _fact   = new FacturaService(configuration);

        }

        // GET: InvoiceController
        public ActionResult Index()
        {
            object result = null;
            if (ModelState.IsValid)
            {
               result =  _fact.getInvoice();
            }
            return View(result);
        }

        // GET: InvoiceController/Details/5
        public ActionResult Details(int id)
        {
           var result = _fact.getInvoice(id);
            return View(result);
        }

        
        // GET: InvoiceController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Invoice v = new Invoice();
                v.CustomerId = Convert.ToInt32(collection["CustomerId"]);
                v.TotalItbis = Convert.ToDecimal(collection["TotalItbis"]);
                v.SubTotal = Convert.ToDecimal(collection["SubTotal"]);
                v.Total = Convert.ToDecimal(collection["Total"]);
                var resul = _fact.setAddInvoice(v);

                return View(resul);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }


        public ActionResult Edit(int id)
        {
            var query = _fact.getInvoice(id);    
        
            return View(query);
        }


        [HttpPost]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Invoice v = new Invoice();
                v.CustomerId = Convert.ToInt32(collection["CustomerId"]);
                v.TotalItbis = Convert.ToDecimal(collection["TotalItbis"]);
                v.SubTotal = Convert.ToDecimal(collection["SubTotal"]);
                v.Total = Convert.ToDecimal(collection["Total"]);
                var resul = _fact.setUpdateInvoice(v);

                return View(resul);
            }
            catch
            {
                return View();
            }
        }

        // GET: InvoiceController/Delete/5
        public ActionResult Delete(int id)
        {
             var reult = _fact.setDeleteInvoice(id);

            return View("Index");
        }

  
    }
}
