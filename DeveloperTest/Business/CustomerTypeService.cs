using System.Linq;

using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Models;

namespace DeveloperTest.Business
{
    public class CustomerTypeService : ICustomerTypeService
    {
        private ApplicationDbContext _context;
        public CustomerTypeService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public CustomerTypeModel[] GetAllCustomerTypes()
        {
            return _context.CustomerTypes
                .Select(x => new CustomerTypeModel { CustomerTypeId = x.CustomerTypeId, Name = x.Name })
                .ToArray();
        }
    }
}
