using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : Controller {
        private readonly ICarService _carService;

        public CarsController(ICarService carService) {
            _carService = carService;
        }

        [HttpGet("getAll")]
        [Authorize(Roles = "Cars.List")]
        public IActionResult GetAll() {
            var result = _carService.GetAll();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id) {
            var result = _carService.GetById(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getCarDetails")]
        public IActionResult GetCarDetails() {
            var result = _carService.GetCarDetails();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        

        [HttpPost("add")]
        public IActionResult Add(Car car) {
            var result = _carService.Add(car);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        
        [HttpPut("update")]
        public IActionResult Update(Car car) {
            var result = _carService.Update(car);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        
        [HttpDelete("delete")]
        public IActionResult Delete(Car car) {
            var result = _carService.Delete(car);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}