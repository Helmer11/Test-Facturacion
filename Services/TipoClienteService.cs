using Test_Schad.Interfaces;
using Test_Schad.Models;

namespace Test_Schand.Services
{
    public class TipoClienteService : ITypeCustome
    {
        private readonly IConfiguration configuration;


        public TipoClienteService(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public IEnumerable<CustomerType> getCustomeType()
        {
            try
            {
                using(var context = new TestInvoiceContext(configuration))
                {
                    var query = context.CustomerTypes.ToList();
                    return query;
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<CustomerType> getCustomeType(int id)
        {
            try
            {
                var idParam = id == 0 ? id = 0 : id;
                using (var context = new TestInvoiceContext(configuration))
                {
                    var query = context.CustomerTypes.Where(x => x.Id == idParam).ToList();
                    return query;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string setAddCustomeType(CustomerType type)
        {
            try
            {
                using(var db = new TestInvoiceContext(configuration))
                {
                    CustomerType custo = new CustomerType()
                    {
                        Description = type.Description,
                    };
                    db.CustomerTypes.Add(custo);
                    db.SaveChanges();
                    return "The type of client was added";

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string setUpdateCustomeType(CustomerType type)
        {
            try
            {
                using(var context = new TestInvoiceContext(configuration))
                {
                    context.Entry(type).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return "The type of client was added";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string setDeleteCustomeType(int id)
        {
            try
            {
                using(var context = new TestInvoiceContext(configuration))
                {
                    context.Entry(id).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return "The type of client was added";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
