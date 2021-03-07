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
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            //Car car = new Car() { CarId = 16, BrandId = 1, ColorId = 1, DailyPrice = 222222, ModelYear = 2000, Description = "araba" };

            //Get Car Details Test
            GetCarDetailsTest(carManager);

            //Get All Tests
            //GetAllCarTest(carManager);
            //GetAllBrandTest(brandManager);
            //GetAllColorTest(colorManager);

            //AddCarTest(carManager);
            //UpdateCarTest(carManager);
            //DeleteCarTest(carManager);

            //Get By Id Tests
            //GetCarByIdTest(carManager, 2);
            //GetBrandByIdTest(brandManager, 6);
            //GetColorByIdTest(colorManager, 1);

            //Get Cars By Color Id And Brand Id Tests
            //GetCarsByBrandIdTest(carManager);
            //GetCarsByColorIdTest(carManager);

            //Add, Update, Delete for Brand Tests
            //AddBrandTest(brandManager);
            //UpdateBrandTest(brandManager);
            //DeleteBrandTest(brandManager);

            //Add, Update, Delete for Color Tests
            //AddColorTest(colorManager);
            //UpdateColorTest(colorManager);
            //DeleteColorTest(colorManager);


            Console.ReadLine();
        }


        private static void GetCarsByColorIdTest(CarManager carManager)
        {
            var result = carManager.GetCarsByColorId(9);
            if (result.Success)
            {
                separator();
                Console.WriteLine("Cars By Color Id List:");
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Car id: " + car.CarId + "\n" + "Car brand id: " + car.BrandId + "\n"
                        + "Car color id: " + car.ColorId + "\n" + "Car model year: " + car.ModelYear + "\n"
                        + "Car name: " + car.Description + "\n" + "Car daily price: " + car.DailyPrice + " TL...");
                }
                Console.WriteLine("----- Get Cars By Color Id Details Tested... -----");
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetCarsByBrandIdTest(CarManager carManager)
        {
            var result = carManager.GetCarsByBrandId(8);
            if (result.Success)
            {
                separator();
                Console.WriteLine("Cars By Brand Id List:");
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Car id: " + car.CarId + "\n" + "Car brand id: " + car.BrandId + "\n"
                        + "Car color id: " + car.ColorId + "\n" + "Car model year: " + car.ModelYear + "\n"
                        + "Car name: " + car.Description + "\n" + "Car daily price: " + car.DailyPrice + " TL ...");
                }
                Console.WriteLine("----- Get Cars By Brand Id Details Tested... -----");
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void DeleteColorTest(ColorManager colorManager)
        {
            colorManager.Delete(new Color() { ColorId = 1003 });
            Console.WriteLine("----- Color Deleted... -----");
        }

        private static void UpdateColorTest(ColorManager colorManager)
        {
            colorManager.Update(new Color() { ColorId = 1005, ColorName = "Mor" });
            Console.WriteLine("----- Color Updated... -----");
        }

        private static void AddColorTest(ColorManager colorManager)
        {
            colorManager.Add(new Color() { ColorName = "Bordo" });
            Console.WriteLine("----- Color Added... -----");
        }

        private static void DeleteBrandTest(BrandManager brandManager)
        {
            brandManager.Delete(new Brand() { BrandId = 1003 });
            Console.WriteLine("----- Brand Deleted... -----");
        }

        private static void UpdateBrandTest(BrandManager brandManager)
        {
            brandManager.Update(new Brand() { BrandId = 1004, BrandName = "Audi" });
            Console.WriteLine("----- Brand Updated... -----");
        }

        private static void AddBrandTest(BrandManager brandManager)
        {
            brandManager.Add(new Brand() { BrandName = "Cadillac" });
            Console.WriteLine("----- Brand Added... -----");
        }

        private static void GetColorByIdTest(ColorManager colorManager, int id)
        {
            separator();
            Console.WriteLine("Color By Id List:");
            var result = colorManager.GetColorById(id);
            Console.WriteLine("Color id: " + result.Data.ColorId + "\n" + "Color name: " + result.Data.ColorName);
            Console.WriteLine("----- Get Color By Id Tested... -----");
        }

        private static void GetBrandByIdTest(BrandManager brandManager, int id)
        {
            separator();
            Console.WriteLine("Brand By Id List:");
            var result = brandManager.GetBrandById(id);
            Console.WriteLine("Brand id: " + result.Data.BrandId + "\n" + "Brand name: " + result.Data.BrandName);
            Console.WriteLine("----- Get Brand By Id Tested... -----");
        }

        private static void GetCarByIdTest(CarManager carManager, int id)
        {
            var result = carManager.GetCarById(id);
            if (result.Success)
            {
                separator();
                Console.WriteLine("Car By Id List:");
                Console.WriteLine("Car id: " + result.Data.CarId + "\n" + "Car brand id: " + result.Data.BrandId + "\n"
                    + "Car color id: " + result.Data.ColorId + "\n" + "Car model year: " + result.Data.ModelYear + "\n"
                    + "Car name: " + result.Data.Description + "\n" + "Car daily price: " + result.Data.DailyPrice + " TL...");
                Console.WriteLine("----- Get Car By Id Tested... -----");
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void AddCarTest(CarManager carManager)
        {
            carManager.Add(new Car() { CarId = 14, BrandId = 1, ColorId = 1, DailyPrice = 111111, ModelYear = 2000, Description = "araba" });
            Console.WriteLine("----- Car Added... -----");
        }

        private static void UpdateCarTest(CarManager carManager)
        {
            carManager.Update(new Car() { CarId = 13, BrandId = 1, ColorId = 1, DailyPrice = 222222, ModelYear = 2000, Description = "araç" });
            Console.WriteLine("----- Car Updated... -----");
        }

        private static void DeleteCarTest(CarManager carManager)
        {
            carManager.Delete(new Car() { CarId = 12, BrandId = 1, ColorId = 1, DailyPrice = 222222, ModelYear = 2000, Description = "araç" });
            Console.WriteLine("----- Car Deleted... -----");
        }

        private static void GetAllCarTest(CarManager carManager)
        {
            var result = carManager.GetAllCar();
            if (result.Success)
            {
                separator();
                Console.WriteLine("Car List:");
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Description);
                    Console.WriteLine("-----Get All Car Tested... -----");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetAllBrandTest(BrandManager brandManager)
        {
            var result = brandManager.GetAllBrand();
            if (result.Success)
            {
                separator();
                Console.WriteLine("Brand List:");
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
                Console.WriteLine("----- Get All Brand Tested... -----");
            }
        }

        private static void GetAllColorTest(ColorManager colorManager)
        {
            var result = colorManager.GetAllColor();
            if (result.Success)
            {
                separator();
                Console.WriteLine("Color List:");
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorName);
                }
                Console.WriteLine("----- Get All Color Tested... -----");
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetCarDetailsTest(CarManager carManager)
        {
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                separator();
                Console.WriteLine("Car Details List:");
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.ColorName + " renk " + car.ModelYear + " Model " + car.BrandName + " "
                        + car.Description + ", fiyatı: " + car.DailyPrice + " TL/Gün");
                }
                Console.WriteLine("----- Get Car Details Tested... -----");
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void separator()
        {
            Console.WriteLine("--------------------------------------------------");
        }

        /*8. gün
         *  Ödev 1
6) Sisteme yeni araba eklendiğinde aşağıdaki kuralları çalıştırınız.
Araba ismi minimum 2 karakter olmalıdır
Araba günlük fiyatı 0'dan büyük olmalıdır.
Ödevinize ait github linkini paylaşınız.
         */
    }
}
