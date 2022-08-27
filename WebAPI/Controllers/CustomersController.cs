using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService) {
            _customerService = customerService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll() {
            var result = _customerService.GetAll();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id) {
            var result = _customerService.GetById(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        
        [HttpGet("getCustomerDetails")]
        public IActionResult GetCustomerDetails() {
            var result = _customerService.GetCustomerDetails();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Customer customer) {
            var result = _customerService.Add(customer);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        
        [HttpPut("update")]
        public IActionResult Update(Customer customer) {
            var result = _customerService.Update(customer);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        
        [HttpDelete("delete")]
        public IActionResult Delete(Customer customer) {
            var result = _customerService.Delete(customer);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}