using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = (from car in filter == null ? context.Cars : context.Cars.Where(filter)
                              join c in context.Colors on car.ColorId equals c.ColorId
                              join d in context.Brands on car.BrandId equals d.BrandId
                              join im in context.CarImages on car.CarId equals im.CarId
                              select new CarDetailDto
                              {
                                  CarId = car.CarId,
                                  CarName = car.CarName,
                                  BrandName = d.BrandName,
                                  ColorName = c.ColorName,
                                  DailyPrice = car.DailyPrice,
                                  Description = car.Description,
                                  ModelYear = car.ModelYear,
                                  Date = im.Date,
                                  ImagePath = im.ImagePath,
                                  ImageId = im.Id,
                                  MinFindeksScore = car.MinFindeksScore
                              }).ToList();
                return result.GroupBy(car => car.CarId).Select(car => car.FirstOrDefault()).ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailById(int carId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from car in context.Cars
                             join c in context.Colors on car.ColorId equals c.ColorId
                             join d in context.Brands on car.BrandId equals d.BrandId
                             join im in context.CarImages on car.CarId equals im.CarId
                             where car.CarId == carId
                             select new CarDetailDto
                             {
                                 CarId = car.CarId,
                                 CarName = car.CarName,
                                 BrandId = car.BrandId,
                                 BrandName = d.BrandName,
                                 ColorId = car.ColorId,
                                 ColorName = c.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 ModelYear = car.ModelYear,
                                 Date = im.Date,
                                 ImagePath = im.ImagePath,
                                 ImageId = im.Id,
                                 MinFindeksScore = car.MinFindeksScore
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByBrandAndColor(int brandId, int colorId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from car in context.Cars.Where
                        (car => car.BrandId == brandId && car.ColorId == colorId)
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join color in context.Colors on car.ColorId equals color.ColorId

                             select new CarDetailDto
                             {
                                 CarId = car.CarId,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 MinFindeksScore = car.MinFindeksScore,
                                 ImagePath = (from carImage in context.CarImages
                                              where (carImage.CarId == car.CarId)
                                              select carImage).FirstOrDefault().ImagePath
                             };
                return result.ToList();
            }
        }
    }
}

