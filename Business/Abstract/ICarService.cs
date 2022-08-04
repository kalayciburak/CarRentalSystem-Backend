using System.Collections.Generic;
using Entities.Concrete;
using Entities.DTO;

namespace Business.Abstract {
    public interface ICarService {
        List<Car> GetAll();
        List<Car> GetCarsByBrandId(int brandId);
        List<Car> GetCarsByColorId(int colorId);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        List<CarDetailDto> GetCarDetails();
    }
}