using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;using System;using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Concrate
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("Car.Add")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

        }
        [SecuredOperation("Car.Delete")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 5)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Car> GetById(int carId)
        {
            if (DateTime.Now.Hour == 5)
            {
                return new ErrorDataResult<Car>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            if (DateTime.Now.Hour == 5)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandAndColor(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByBrandAndColor(brandId, colorId));
        }
        public IDataResult<List<CarDetailDto>> GetCarDetailsById(int carId)
        {
            if (DateTime.Now.Hour == 5)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailById(carId));
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarBrandandColor(int brandId, int colorId)
        {
            if (DateTime.Now.Hour == 5)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(p => p.BrandId == brandId && p.ColorId == colorId));
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsDetailByBrandId(int brandId)
        {
            if (DateTime.Now.Hour == 5)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(p => p.BrandId == brandId));
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsDetailByColorId(int colorId)
        {
            if (DateTime.Now.Hour == 5)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(p => p.ColorId == colorId));
        }


        //[SecuredOperation("Car.Update")]
        public IResult Update(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.CarUpdated);
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.CarPriceInvalid);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {

            Add(car);
            if (car.DailyPrice < 10)
            {
                throw new Exception("");
            }

            Add(car);

            return null;
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Car car)
        {
            _carDal.Update(car);
            _carDal.Add(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}

/*



[CacheAspect] //key,value

        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetAllCar()
        {
            if (DateTime.Now.Hour == 21)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }
        //[SecuredOperation("Product.List,Admin")]
        [LogAspect(typeof(FileLogger))]
        [CacheAspect(duration: 10)]
        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == brandId));
        }

        //[SecuredOperation("Product.List,Admin")]
        [LogAspect(typeof(FileLogger))]
        [CacheAspect(duration: 10)]
        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorId == colorId));
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<CarDetailDto>> GetCarById(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.CarId == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            if (car.Description.Length < 2)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated); 
        }



        IDataResult<CarDetailDto> ICarService.GetCarById(int carId)
        {
            throw new NotImplementedException();
        }
    }
}*/
