using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Operations;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Linq.Expressions;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Entities.DTOs;
using Core.Aspects.Autofac.Validation;
using Business.BusinessAspects.Autofac;

namespace Business.Concrate
{
    public class CarImageManager: ICarImageService
    {
        ICarImageDal _carImageDal;
        private ICarService _carService;
        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService;
        }

        [CacheAspect]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<CarImage> Get(int id)
        {
            var carImage = _carImageDal.Get(ci => ci.Id == id);
            if (carImage == null) return new ErrorDataResult<CarImage>(Messages.CarImageNotFound);
            return new SuccessDataResult<CarImage>(carImage);
        }

        public IDataResult<List<CarDetailDto>> GetByCarId(int carId)
        {
            var result = _carService.GetCarDetails(ci => ci.CarId == carId);
            if (result.Data.Any()) return new SuccessDataResult<List<CarDetailDto>>(result.Data);
            return new SuccessDataResult<List<CarDetailDto>>(new List<CarDetailDto>
            {
                new CarDetailDto{ ImagePath = "logo.jpg", Date = DateTime.Now }
            });
        }

        // [SecuredOperation("CarImage.Add")]
        //[ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckCarImagesCount(carImage.CarId));
            if (result != null) return result;
            carImage.ImagePath = FileOperations.SaveImageFile("Images", file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        //[ValidationAspect(typeof(CarImageValidator))]
        [SecuredOperation("CarImage.Update")]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            var entity = _carImageDal.Get(ci => ci.Id == carImage.Id);
            if (entity == null) return new ErrorResult(Messages.CarImageNotFound);
            FileOperations.DeleteImageFile(entity.ImagePath);
            entity.ImagePath = FileOperations.SaveImageFile("Images", file);
            entity.Date = DateTime.Now;
            _carImageDal.Update(entity);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        [SecuredOperation("CarImage.Delete")]
        public IResult Delete(CarImage carImage)
        {
            var entity = _carImageDal.Get(ci => ci.Id == carImage.Id);
            if (entity == null) return new ErrorResult(Messages.CarImageNotFound);
            FileOperations.DeleteImageFile(entity.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.DeletedCarImage);
        }
        private IResult CheckCarImagesCount(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId).Count < 5;
            if (!result) return new ErrorResult(Messages.CarImageLimitExceeded);
            return new SuccessResult();
        }
    }
}
