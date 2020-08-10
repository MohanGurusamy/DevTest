
using DeveloperTest.Business.Interfaces;

using Microsoft.AspNetCore.Mvc;


namespace DeveloperTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerTypeController : ControllerBase
    {
        private ICustomerTypeService _service;
        public CustomerTypeController(ICustomerTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var types = _service.GetAllCustomerTypes();
            return Ok(types);
        }
    }
}
