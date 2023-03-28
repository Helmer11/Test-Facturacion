using Test_Schad.Interfaces;
using Test_Schad.Models;

namespace Test_Schand.Services
{
    public class ClienteService : ICustome
{
    private readonly IConfiguration context;

    public ClienteService(IConfiguration _context)
    {
        context = _context;
    }

    public IEnumerable<Customer> getCustome()
    {
            try
            {
                using (var db = new TestInvoiceContext(context))
                {
                    var query = db.Customers.ToList();

                    return query;
                }
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
    }

    public string setAddCustome(Customer cust)
    {
            try
            {
                using(var db = new TestInvoiceContext(context))
                {
                    Customer c = new Customer()
                    {
                        CustName = cust.CustName,
                        Adress = cust.Adress,
                        Status = cust.Status,
                        CustomerType = cust.CustomerType
                    };
                    db.Customers.Add(c);
                    db.SaveChanges();
                    return "the client was added";
                }
            
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
    }

    public string setUpdateCustome(Customer cust)
    {
            try
            {
                using(var db = new TestInvoiceContext(context))
                {
                    db.Entry(cust).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                    db.SaveChanges();
                    return "Client data updated";
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }   
    }

    public string setDeleteCustome(int id)
    {
            try
            {
                using(var db = new TestInvoiceContext(context))
                {
                    db.Entry(id).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    return "the client was deleted";
                }
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }       
    }


     

}

}
