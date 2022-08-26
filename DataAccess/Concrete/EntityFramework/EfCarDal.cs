using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;

namespace DataAccess.Concrete.EntityFramework {
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal {
        public List<CarDetailDto> GetCarDetails() {
            using var context = new CarRentalContext();
            var result = from car in context.Cars
                join brand in context.Brands on car.BrandId equals brand.BrandId
                join color in context.Colors on car.ColorId equals color.ColorId
                select new CarDetailDto {
                    CarId = car.CarId,
                    CarName = car.Description,
                    BrandName = brand.BrandName,
                    ColorName = color.ColorName,
                    DailyPrice = car.DailyPrice
                };

            return result.ToList();
        }
    }
}