using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemoryDal;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            CarManager carManager = new CarManager(new EfCarDal());

            Car car = new Car();
             car.BrandId = 1;
             car.ColorId = 3;
             car.DailyPrice = 0;
             car.Description = "Tifdfd";
             car.ModelYear = 2010;
             carManager.Add(car);

            /*  foreach (var item in carManager.GetAll())
              {
                  Console.WriteLine("{0,-5}{1,-5}{2,-5}{3,-10}{4,10}" ,item.CarId,item.BrandId,item.ColorId,item.DailyPrice,item.Description);


              }*/

            /*foreach (var item in carManager.GetCarsByBrandId(3))
            {
                Console.WriteLine("{0,-5}{1,-5}{2,-5}{3,-10}{4,10}", item.CarId, item.BrandId, item.ColorId, item.DailyPrice, item.Description);
            }*/

           /* foreach (var item in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine("{0,-5}{1,-5}{2,-5}{3,-10}{4,10}", item.CarId, item.BrandId, item.ColorId, item.DailyPrice, item.Description);
            }*/
               
        }
    }
}
