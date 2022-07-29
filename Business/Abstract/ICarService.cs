using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Abstract {
    public interface ICarService {
        List<Car> GetAll();
    }
}