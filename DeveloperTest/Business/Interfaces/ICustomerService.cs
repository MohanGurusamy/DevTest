using DeveloperTest.Models;

namespace DeveloperTest.Business.Interfaces
{
    public interface ICustomerService
    {
        CustomerModel[] GetAllCustomers();
        CustomerModel GetCustomer(int id);
        CustomerModel AddCustomer(BaseCustomerModel model);
    }
}
