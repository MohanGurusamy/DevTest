using DeveloperTest.Models;

namespace DeveloperTest.Business.Interfaces
{
    public interface ICustomerTypeService
    {
        CustomerTypeModel[] GetAllCustomerTypes();
    }
}
