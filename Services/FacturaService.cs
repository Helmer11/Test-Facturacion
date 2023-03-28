using Test_Schad.Interfaces;
using Test_Schad.Models;

namespace Test_Schad.Services
{
    public delegate void UpdateTotalInvoice(decimal subtotal, decimal total, Invoice invoice);

    public class FacturaService : IInvoice
    {
        private readonly IConfiguration configuration;

        public FacturaService(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public IEnumerable<Invoice> getInvoice()
        {
            try
            {
                using (var context = new TestInvoiceContext(configuration))
                {
                    var query = context.Invoices.ToList();
                    return query;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Invoice> getInvoice(int id)
        {
            try
            {
                var idParam = id == 0 ? id = 0 : id;
                using (var context = new TestInvoiceContext(configuration))
                {
                    var query = context.Invoices.Where(x => x.Id == idParam).ToList();
                    return query;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string setAddInvoice(Invoice invoice)
        {
            try
            {
                using (var db = new TestInvoiceContext(configuration))
                {
                    Invoice factura = new Invoice()
                    {
                        CustomerId = invoice.CustomerId,
                        TotalItbis = invoice.TotalItbis,
                        SubTotal = invoice.SubTotal,
                        Total = invoice.Total,
                    };
                    db.Invoices.Add(factura);
                    db.SaveChanges();
                    return "the invoice was added";

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void setUpdateTotales( decimal subtotal, decimal total, Invoice invoice)
        {
            try
            {
                using (var context = new TestInvoiceContext(configuration))
                {
                    context.Entry(invoice).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges(); 
                }
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public string setUpdateInvoice(Invoice invoice)
        {
            try
            {
                UpdateTotalInvoice delega = new UpdateTotalInvoice(setUpdateTotales);

                return "the invoice was updated";
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string setDeleteInvoice(int id)
        {
            try
            {
                using (var context = new TestInvoiceContext(configuration))
                {
                    context.Entry(id).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return "The record is deleted";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<InvoiceDetail> getInvoiceDetaol(int id)
        {
            try
            {
                var idParam = id == 0 ? id = 0 : id;
                using (var context = new TestInvoiceContext(configuration))
                {
                    var query = context.InvoiceDetails.Where(x => x.Id == idParam).ToList();
                    return query;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}
