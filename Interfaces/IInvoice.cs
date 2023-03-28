using Test_Schad.Models;

namespace Test_Schad.Interfaces
{
    public interface IInvoice
    {
        IEnumerable<Invoice> getInvoice();
        IEnumerable<Invoice> getInvoice(int id);
        string setAddInvoice(Invoice invoice);
        string setUpdateInvoice(Invoice invoice);
        string setDeleteInvoice(int id);
        IEnumerable<InvoiceDetail> getInvoiceDetaol(int id);


    }
}
