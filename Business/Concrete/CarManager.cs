using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete {
    public class CarManager : ICarService {
        ICarDal _carDal;

        public CarManager(ICarDal carDal) {
            _carDal = carDal;
        }

        public List<Car> GetAll() {
            // iş kodları
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int brandId) {
            return _carDal.GetAll(c => c.BrandId == brandId).ToList();
        }

        public List<Car> GetCarsByColorId(int colorId) {
            return _carDal.GetAll(c => c.ColorId == colorId).ToList();
        }

        public void Add(Car car) {
            if (car.Description.Length >= 2 && car.DailyPrice > 0) {
                _carDal.Add(car);
                Console.WriteLine($"Kayıt başarıyla eklendi. {car.ModelYear} {car.DailyPrice}$, {car.Description}");
            }
            else {
                Console.WriteLine("Kayıt işlemi başarısız");
            }
        }

        public void Update(Car car) {
            throw new System.NotImplementedException();
        }

        public void Delete(Car car) {
            throw new System.NotImplementedException();
        }
    }
}