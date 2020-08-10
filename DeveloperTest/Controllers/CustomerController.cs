
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Models;

using Microsoft.AspNetCore.Mvc;


namespace DeveloperTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _service;
        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var customers = _service.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = _service.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);

        }

        [HttpPost]
        public IActionResult Create(BaseCustomerModel baseCustomer)
        {
            var customer = _service.AddCustomer(baseCustomer);
            return Created($"customer/${customer.CustomerId}", customer);
        }
    }
}
