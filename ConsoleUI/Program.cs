﻿using Business.Concrate;
using DataAccess.Concrate.EntityFramework;
using DataAccess.Concrate.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal() );

            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.Description);
            }
            Console.ReadLine();
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
