using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory {
    public class InMemoryCarDal : ICarDal {
        private readonly List<Car> _cars;

        public InMemoryCarDal() {
            _cars = new List<Car> {
                new() {
                    CarId = 1, BrandId = 1, ColorId = 2, ModelYear = 1996, DailyPrice = 200000, Description = "Klasik"
                },
                new() {
                    CarId = 2, BrandId = 2, ColorId = 1, ModelYear = 2022, DailyPrice = 999999,
                    Description = "Süper hızlı"
                },
                new() {
                    CarId = 3, BrandId = 3, ColorId = 1, ModelYear = 2005, DailyPrice = 350000,
                    Description = "Dizel vs."
                },
            };
        }

        public List<Car> GetAll() {
            return _cars;
        }

        public Car GetById(int id) {
            return _cars.SingleOrDefault(c => c.CarId == id);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null) {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter) {
            throw new NotImplementedException();
        }

        public void Add(Car car) {
            _cars.Add(car);
        }

        public void Update(Car car) {
            var carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            
            if (carToUpdate == null) return;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        public void Delete(Car car) {
            var carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }
    }
}