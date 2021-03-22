using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetailsById(int id)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result =
                    from r in context.Rentals.Where(c => c.CarId == id)
                    join c in context.Cars on r.CarId equals c.CarId
                    join cu in context.Customers on r.CustomerId equals cu.Id
                    join b in context.Brands on c.BrandId equals b.BrandId
                    join co in context.Colors on c.ColorId equals co.ColorId
                    join u in context.Users on cu.UserId equals u.Id
                    join user in context.Users on cu.UserId equals user.Id
                    select new RentalDetailDto
                    {
                        Id = r.Id,
                        CarName = c.CarName,

                        CarId = c.CarId,
                        BrandName = b.BrandName,
                        ColorName = co.ColorName,

                        CustomerName = cu.CompanyName,
                        UserName = $"{u.FirstName} {u.LastName}",
                        RentDate = r.RentDate,
                        ReturnDate = r.ReturnDate,
                        DailyPrice = c.DailyPrice,
                        Description = c.Description,
                        Email = user.Email,
                        ModelYear = c.ModelYear
                    };
                return result.ToList();
            }
        }
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             join car in context.Cars on r.CarId equals car.CarId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join customer in context.Customers on r.CustomerId equals customer.Id
                             join user in context.Users on customer.UserId equals user.Id

                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 CarId = car.CarId,
                                 CarName = car.CarName,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 Description = car.Description,
                                 CustomerName = user.FirstName +" "+ user.LastName,
                                 Email = user.Email,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
