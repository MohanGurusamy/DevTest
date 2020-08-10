using System.Linq;

using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Models;

namespace DeveloperTest.Business
{
    public class CustomerService : ICustomerService
    {
        private ApplicationDbContext _context;
        public CustomerService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public CustomerModel AddCustomer(BaseCustomerModel model)
        {
            var addedCustomer = _context
            .Customers
            .Add(new Customer
            {
                CustomerTypeId = model.CustomerTypeId,
                Name = model.Name
            });
            _context.SaveChanges();
            var id = addedCustomer.Entity.CustomerId;

            var newCustomer = _context.Customers
                .Where(x => x.CustomerId == id)
                .Select(x=>new
                {
                    x.CustomerId,
                    CustomerTypeName = x.CustomerType.Name,
                    x.Name
                })
                .Single();
            return new CustomerModel
            {
                CustomerId = newCustomer.CustomerId,
                CustomerTypeName = newCustomer.CustomerTypeName,
                Name = newCustomer.Name
            };
        }

        public CustomerModel[] GetAllCustomers()
        {
            return _context.Customers
                .Select(x => new CustomerModel
                {
                    CustomerId = x.CustomerId,
                    CustomerTypeName = x.CustomerType.Name,
                    Name = x.Name
                }).ToArray();
        }

        public CustomerModel GetCustomer(int id)
        {
            var customer = _context.Customers
                .Where(x => x.CustomerId == id)
                .Select(x => new
                {
                    x.CustomerId,
                    x.Name,
                    TypeName = x.CustomerType.Name
                })
                .SingleOrDefault();

            return customer != null ? new CustomerModel
            {
                CustomerId = customer.CustomerId,
                CustomerTypeName = customer.TypeName,
                Name = customer.Name
            } : null;
        }
    }
}
