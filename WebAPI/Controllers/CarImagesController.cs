using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : Controller {
        private ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService) {
            _carImageService = carImageService;
        }
        
        [HttpGet("getAll")]
        public IActionResult GetAll() {
            var result = _carImageService.GetAll();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id) {
            var result = _carImageService.GetById(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        
        [HttpGet("getCarImagesByCarId")]
        public IActionResult GetCarImagesByCarId(int carId) {
            var result = _carImageService.GetCarImagesByCarId(carId);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] CarImage carImage,[FromForm(Name = "Image")] IFormFile formFile) {
            var result = _carImageService.Add(carImage,formFile);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update([FromForm] CarImage carImage,[FromForm(Name = "ImagePath")] IFormFile formFile) {
            var result = _carImageService.Update(carImage,formFile);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(CarImage carImage) {
            var result = _carImageService.Delete(carImage);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}