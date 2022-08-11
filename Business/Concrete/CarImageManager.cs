using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete {
    public class CarImageManager : ICarImageService {
        private ICarImageDal _carImageDal;
        private IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper) {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IDataResult<List<CarImage>> GetAll() {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int imageId) {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarImageId == imageId));
        }

        public IDataResult<List<CarImage>> GetCarImagesByCarId(int carId) {
            var result = BusinessRules.Run(CheckIfCarHasImage(carId));

            if (result == null)
                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));

            var carImage = new List<CarImage>();
            carImage.Add(new CarImage {
                CarId = carId,
                ImagePath = Paths.PlaceholderCarImagePath,
                DateAdded = DateTime.Now
            });
            return new SuccessDataResult<List<CarImage>>(carImage);
        }

        public IResult Add(CarImage carImage, IFormFile formFile) {
            var result = BusinessRules.Run(CheckIfImageLimitIsExceeded(carImage.CarId));
            if (result != null) {
                return result;
            }

            carImage.ImagePath = _fileHelper.AddFile(formFile, Paths.CarImagesPath);
            carImage.DateAdded = DateTime.Now;

            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Update(CarImage carImage, IFormFile formFile) {
            carImage.ImagePath = _fileHelper.UpdateFile(formFile, Paths.CarImagesPath + carImage.ImagePath,
                Paths.CarImagesPath);
            carImage.DateAdded = DateTime.Now;

            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage) {
            _fileHelper.DeleteFile(Paths.CarImagesPath + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        private IResult CheckIfImageLimitIsExceeded(int carId) {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5) return new ErrorResult(Messages.ImageLimitExceeded);
            return new SuccessResult();
        }

        private IResult CheckIfCarHasImage(int carId) {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 0) return new SuccessResult();
            return new ErrorResult();
        }
    }
}