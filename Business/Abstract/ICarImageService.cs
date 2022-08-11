using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract {
    public interface ICarImageService {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int imageId);
        IDataResult<List<CarImage>> GetCarImagesByCarId(int carId);
        IResult Add(CarImage carImage,IFormFile file);
        IResult Update(CarImage carImage,IFormFile formFile);
        IResult Delete(CarImage carImage);
    }
}