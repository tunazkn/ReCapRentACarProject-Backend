using Business.Concrate;
using DataAccess.Concrate.EntityFramework;
using DataAccess.Concrate.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car() { CarId = 1006, BrandId = 1, ColorId = 1, DailyPrice = 222222, ModelYear = 2000, Description = "araba yeni" };
            //CarTest();
            //BrandTest();
            //ColorTest();

            //addTheCar(carManager);
            //updateTheCar(carManager, car);
            //deleteTheCar(carManager, car);
            Console.ReadLine();
        }

        private static void updateTheCar(CarManager carManager, Car car)
        {
            carManager.Update(car);
            Console.WriteLine("updated");
        }

        private static void deleteTheCar(CarManager carManager, Car car)
        {
            carManager.Delete(car);
        }

        private static void addTheCar(CarManager carManager)
        {
            carManager.Add(new Car() {BrandId = 1, ColorId = 1, DailyPrice = 111111, ModelYear = 2000, Description = "araba" });
            Console.WriteLine("Car Added");
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.BrandName+ " " +   car.Description + ", renk: " + car.ColorName);
            }
        }


        /*8. gün
         *  Ödev 1
Araba Kiralama projemiz üzerinde çalışmaya devam edeceğiz.
Car nesnesine ek olarak;
1) Brand ve Color nesneleri ekleyiniz(Entity)
Brand-->Id,Name
Color-->Id,Name
2) Sql Server tarafında yeni bir veritabanı kurunuz. Cars,Brands,Colors tablolarını oluşturunuz. (Araştırma)
3) Sisteme Generic IEntityRepository altyapısı yazınız.
4) Car, Brand ve Color nesneleri için Entity Framework altyapısını yazınız.
5) GetCarsByBrandId , GetCarsByColorId servislerini yazınız.
6) Sisteme yeni araba eklendiğinde aşağıdaki kuralları çalıştırınız.
Araba ismi minimum 2 karakter olmalıdır
Araba günlük fiyatı 0'dan büyük olmalıdır.
Ödevinize ait github linkini paylaşınız.
         */
    }
}
