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
             CarDetailDtoTest();
            // CarDetailDtoGetById(2);
            //---------------------BrandManager Tests--------------------------------------
            // BrandAddTest();
            // BrandUpdateTest();
            // BrandDeleteTest();
            // BrandGetAllTest();
            // BrandGetByIdTest();
            //---------------------CustomerManager Tests--------------------------------------
            // CustomerAddTest();
            //---------------------UserManager Tests--------------------------------------
            // UserAddTest();
            // ModelAddTest();

             // RentalAddTest();

        }

        private static void RentalAddTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            Rental rental = new Rental()
            {
                CustomerId = 3,
                CarId = 2,
                RentDate = DateTime.Today

            };
            var result = rentalManager.Add(rental);
            Console.WriteLine(result.Message);
        }

        private static void ModelAddTest()
        {
            ModelManager modelManager = new ModelManager(new EfModelDal());
            Random random = new Random();
            Model model = new Model()
            {
                ModelName = "CLK",
                ModelYear = random.Next(1999, 2022),


            };

            modelManager.Add(model);
        }

        private static void CustomerAddTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Customer customer = new Customer()
            {
                CompanyName = "Yazılımcı",
                UserId = 1

            };

            customerManager.Add(customer);
        }

        private static void UserAddTest()
        {
            
            UserManager userManager = new UserManager(new EfUserDal());
            User user = new User()
            {
                FirstName = "Leyla",
                LastName = "Çoban",
                Email = "Leylacoban@hotmail.com",
                Password = "rtrtete5584"

            };

            var result = userManager.Add(user);
            Console.WriteLine(result.Message);
        }





        #region CarTest
        private static void CarDetailDtoGetById(int carId)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            CarDetailDto dto = carManager.GetCarDetails().Data.SingleOrDefault(c => c.CarId == carId);
            Console.WriteLine("{0,-5}{1,-10} {2,-10}{3,-15}", dto.CarId, dto.BrandName, dto.ColorName, dto.DailyPrice);
        }

        private static void CarDetailDtoTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("{0,-5}{1,-15} {2,-10}{3,-15}{4,-15}{5,-15}", car.CarId, car.BrandName, car.ModelName,car.ColorName,car.ModelYear, car.DailyPrice);
                }
               
            }
            else
            {
                Console.WriteLine(result.Message);

            }

        }

        private static void CarDeleteTest(int carId)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = carManager.GetAll().Data.SingleOrDefault(c => c.Id == carId);
            carManager.Delete(car);
            Console.WriteLine("ID'si {0}  Araba Silindi ", car.Id);
        }

        private static void CarUpdateTest(int carId)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = carManager.GetAll().Data.SingleOrDefault(c => c.Id == carId);
            car.BrandId = 5;
            car.ColorId = 4;
            car.DailyPrice = 125;
            car.Description = "Öylesine Bir Araba";
            carManager.Update(car);
            Console.WriteLine("ID'si {0}  Araba Güncellendi ", car.Id);
        }
        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Random random = new Random();
            Car car = new Car();
            car.BrandId = 3;
            car.ColorId = 4;
            car.ModelId = 1;
            car.DailyPrice = random.Next(100, 500);
            car.Description = "Binek Araba";
            carManager.Add(car);

        }
        #endregion

        #region BrandTest
        private static void BrandGetByIdTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand br = brandManager.GetById(8).Data;
            Console.WriteLine("{0,-5}{1,-10}", br.Id, br.BrandName);
        }

        private static void BrandGetAllTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine("{0,-5}{1,-10}", brand.Id, brand.BrandName);
            }
        }

        private static void BrandDeleteTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand = new Brand();
            brand.Id = 7;
            brandManager.Delete(brand);
        }

        private static void BrandUpdateTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand = new Brand();
            brand.Id = 7;
            brand.BrandName = "Alfa Romeo";
            brandManager.Update(brand);
        }

        private static void BrandAddTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand = new Brand();
            brand.BrandName = "Toyota";
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

            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine("{0,-5}{1,-10}", color.Id, color.ColorName);
            }
        }
        private static void ColorDeleteTest(int colorId)
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color cl = colorManager.GetAll().Data.SingleOrDefault(c => c.Id == colorId);

            colorManager.Delete(cl);

            Console.WriteLine("ID'si {0} olan ColorName'i {1} olan satır silindi ", cl.Id, cl.ColorName);
        }
        private static void ColorUpdateTest(int colorId)
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color cl = colorManager.GetAll().Data.SingleOrDefault(c => c.Id == colorId);
            cl.ColorName = "Kırmızı";
            colorManager.Update(cl);

            Console.WriteLine("ID'si {0} olan satırın ColorName değeri {1} olarak Güncellendi ", cl.Id, cl.ColorName);
        }
        private static void ColorGetByIdTest(int colorId)
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color colorEntity = colorManager.GetById(colorId).Data;
            Console.WriteLine(colorEntity.ColorName);
        }
        #endregion


    }
}
