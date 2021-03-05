using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrate.InMemory
{
    //GetById, GetAll, Add, Update, Delete
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{CarId=1, BrandId=1, ColorId=1, DailyPrice=1000, ModelYear=2021, Description="an example"},
                new Car{CarId=2, BrandId=2, ColorId=4, DailyPrice=1500, ModelYear=2021, Description="an example2"},
                new Car{CarId=3, BrandId=1, ColorId=3, DailyPrice=3000, ModelYear=2020, Description="an example3"},
                new Car{CarId=4, BrandId=3, ColorId=1, DailyPrice=2000, ModelYear=2020, Description="an example4"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.CarId == car.CarId);
            _cars.Remove(car);
        }
        public List<Car> GetAll()
        {
            return _cars;
        }
        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.CarId == id).ToList();
        }
    }
}
