using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        //[ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        //[SecuredOperation("Rental.Add")]
        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate == null && _rentalDal.GetRentalDetailsById(rental.CarId).Count > 0)
                return new ErrorResult(Messages.notReturned);

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }
        public bool CheckReturnDate(int carId)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId && r.ReturnDate == null);
            if (result.Count > 0)
            {
                return false;
            }
            return true;
        }

        [SecuredOperation("Rental.Delete")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<Rental> GetRentalByCarId(int carId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(c => c.CarId == carId));
        }
        public IDataResult<Rental> GetRentalByCustomerId(int customerId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(c => c.CustomerId == customerId));
        }

        public IDataResult<Rental> GetRentalById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(c => c.Id == rentalId));
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Rental> GetById(int id)
        {
            if (DateTime.Now.Hour == 00)
            {
                return new ErrorDataResult<Rental>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Rental>(_rentalDal.Get(b => b.Id == id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsById(int id)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetailsById(id));
        }

        [CacheAspect]
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            if (DateTime.Now.Hour == 00)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        [SecuredOperation("Rental.Update")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}