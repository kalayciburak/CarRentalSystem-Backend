using System.Collections.Generic;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTO;

namespace DataAccess.Abstract {
    public interface ICarDal:IEntityRepository<Car> {
        List<CarDetailDto> GetCarDetails();
    }
}