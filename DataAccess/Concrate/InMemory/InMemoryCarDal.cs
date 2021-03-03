using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrate.InMemory
{
    //GetById, GetAll, Add, Update, Delete
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> { };
        }
        public List<Car> GetAll()
        {
            throw new NotImplementedException();
        }
        public List<Car> GetById(int id)
        {
            throw new NotImplementedException();
        }
        public void Add(Car car)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            throw new NotImplementedException();
        }

    }
}
