using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemoryDal;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //---------------------ColorManager Tests--------------------------------------
            // ColorAddTest();
            // ColorDeleteTest(6);
            // ColorUpdateTest(2);
            // ColorGetAllTest();
            // ColorGetByIdTest(5);
            //---------------------CarManager Tests--------------------------------------
            // CarAddTest();
            // CarUpdateTest(1);
            // CarDeleteTest(2);
            //--------------------DTO Test-------------------------------------------------
            // CarDetailDtoTest();
            // CarDetailDtoGetById(2);
            //---------------------BrandManager Tests--------------------------------------
            // BrandAddTest();
            // BrandUpdateTest();
            // BrandDeleteTest();
            // BrandGetAllTest();
            // BrandGetByIdTest();



        }

        #region CarTest
        private static void CarDetailDtoGetById(int carId)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            CarDetailDto dto = carManager.GetCarDetails().SingleOrDefault(c => c.CarId == carId);
            Console.WriteLine("{0,-5}{1,-10} {2,-10}{3,-15}", dto.CarId, dto.BrandName, dto.ColorName, dto.DailyPrice);
        }

        private static void CarDetailDtoTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("{0,-5}{1,-10} {2,-10}{3,-15}", car.CarId, car.BrandName, car.ColorName, car.DailyPrice);
            }
        }

        private static void CarDeleteTest(int carId)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = carManager.GetAll().SingleOrDefault(c => c.CarId == carId);
            carManager.Delete(car);
            Console.WriteLine("ID'si {0}  Araba Silindi ", car.CarId);
        }

        private static void CarUpdateTest(int carId)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = carManager.GetAll().SingleOrDefault(c => c.CarId == carId);
            car.BrandId = 5;
            car.ColorId = 4;
            car.DailyPrice = 125;
            car.Description = "Öylesine Bir Araba";
            carManager.Update(car);
            Console.WriteLine("ID'si {0}  Araba Güncellendi ", car.CarId);
        }
        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Random r = new Random();
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Car car = new Car();
            car.BrandId = r.Next(brandManager.GetAll().Count() + 1);
            car.ColorId = r.Next(colorManager.GetAll().Count() + 1);
            car.DailyPrice = r.Next(100, 500);
            car.Description = "Binek Araba";
            car.ModelYear = r.Next(2001, 2021);
            carManager.Add(car);

            Console.WriteLine("Araba Eklendi");
        }
        #endregion

        #region BrandTest
        private static void BrandGetByIdTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand br = brandManager.GetById(8);
            Console.WriteLine("{0,-5}{1,-10}", br.BrandId, br.BrandName);
        }

        private static void BrandGetAllTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("{0,-5}{1,-10}", brand.BrandId, brand.BrandName);
            }
        }

        private static void BrandDeleteTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand = new Brand();
            brand.BrandId = 7;
            brandManager.Delete(brand);
        }

        private static void BrandUpdateTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand = new Brand();
            brand.BrandId = 7;
            brand.BrandName = "Alfa Romeo";
            brandManager.Update(brand);
        }

        private static void BrandAddTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand = new Brand();
            brand.BrandName = "Alfa Romeo";
            brandManager.Add(brand);
        }
        #endregion

        #region ColorTest
        private static void ColorAddTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color = new Color();
             color.ColorName = "Gri" ;
            colorManager.Add(color);

            Console.WriteLine("Eklendi");
        }
        private static void ColorGetAllTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("{0,-5}{1,-10}", color.ColorId, color.ColorName);
            }
        }
        private static void ColorDeleteTest(int colorId)
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color cl = colorManager.GetAll().SingleOrDefault(c => c.ColorId == colorId);

            colorManager.Delete(cl);

            Console.WriteLine("ID'si {0} olan ColorName'i {1} olan satır silindi ", cl.ColorId, cl.ColorName);
        }
        private static void ColorUpdateTest(int colorId)
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color cl = colorManager.GetAll().SingleOrDefault(c => c.ColorId == colorId);
            cl.ColorName = "Kırmızı";
            colorManager.Update(cl);

            Console.WriteLine("ID'si {0} olan satırın ColorName değeri {1} olarak Güncellendi ", cl.ColorId, cl.ColorName);
        }
        private static void ColorGetByIdTest(int colorId)
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color colorEntity = colorManager.GetById(colorId);
            Console.WriteLine(colorEntity.ColorName);
        }
        #endregion


    }
}
