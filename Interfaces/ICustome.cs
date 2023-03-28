using Test_Schad.Models;

namespace Test_Schad.Interfaces
{
    public interface ICustome
    {
        IEnumerable<Customer> getCustome();

        string setAddCustome(Customer cust);


        string setUpdateCustome(Customer cust);

        string setDeleteCustome(int id);




    }
}
