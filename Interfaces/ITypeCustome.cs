using Test_Schad.Models;

namespace Test_Schad.Interfaces
{
    public interface ITypeCustome
    {

        IEnumerable<CustomerType> getCustomeType();
        IEnumerable<CustomerType> getCustomeType(int id);
        string setAddCustomeType(CustomerType type);
        string setUpdateCustomeType(CustomerType type);
        string setDeleteCustomeType(int id);




    }
}
