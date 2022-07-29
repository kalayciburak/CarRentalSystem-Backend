using System.Collections.Generic;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete {
    public class CarManager : ICarService{
        
        ICarDal _carDal;

        public CarManager(ICarDal carDal) {
            _carDal = carDal;
        }

        public List<Car> GetAll() {
            // iş kodları
            return _carDal.GetAll();
        }
    }
}