using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;

namespace Business.Concrete {
    public class CarManager : ICarService {
        readonly ICarDal _carDal;

        public CarManager(ICarDal carDal) {
            _carDal = carDal;
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll() {
            // iş kodları
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId) {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId).ToList());
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId) {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId).ToList());
        }
        
        // [PerformanceAspect(5)]
        public IDataResult<Car> GetById(int id) {
            // Thread.Sleep(6000);
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id));
        }

        // [ValidationAspect(typeof(CarValidatior))]
        [CacheRemoveAspect("ICarService.Get")]
        [TransactionScopeAspect]
        public IResult Add(Car car) {
            _carDal.Add(car);
            // Test scenerio for transaction scope
            if (car.ModelYear > DateTime.Now.Year) {
                throw new Exception(message: "Model year can not be greater than current year");
            }
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Update(Car car) {
            _carDal.Update(car);
            return new SuccessResult();
        }

        public IResult Delete(Car car) {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails() {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
    }
}