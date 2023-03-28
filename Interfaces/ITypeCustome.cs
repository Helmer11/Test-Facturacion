using Test_Schad.Models;

namespace Test_Schad.Interfaces
{
    public interface ITypeCustome
    {

        IEnumerable<CustomerType> getCustomeType();
        string setAddCustomeType(CustomerType type);
        string setUpdateCustomeType(CustomerType type);
        string setDeleteCustomeType(int id);




    }
}
