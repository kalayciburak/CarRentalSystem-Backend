using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework {
    public class EfCarDal : ICarDal {
        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null) {
            using var context = new CarRentalContext();
            return filter == null 
                ? context.Cars.ToList() 
                : context.Cars.Where(filter).ToList();
        }

        public Car Get(Expression<Func<Car, bool>> filter) {
            using var context = new CarRentalContext();
            return context.Cars.FirstOrDefault(filter);
        }

        public void Add(Car entity) {
            using var context = new CarRentalContext();
            context.Cars.Add(entity);
            context.SaveChanges();
        }

        public void Update(Car entity) {
            using var context = new CarRentalContext();
            context.Cars.Update(entity);
            context.SaveChanges();
        }

        public void Delete(Car entity) {
            using var context = new CarRentalContext();
            context.Cars.Remove(entity);
            context.SaveChanges();
        }
    }
}