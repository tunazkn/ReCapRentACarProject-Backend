using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
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
                                 CarName = car.Description,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 CustomerName = user.FirstName +" "+ user.LastName,
                                 Email = user.Email,
                                 CompanyName = customer.CompanyName,
                                 RentDate = r.RentDate.ToShortDateString(),
                                 ReturnDate = r.ReturnDate.ToString()

                             };
                return result.ToList();
            }
        }
    }
}
