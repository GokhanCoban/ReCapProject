using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectDBContext>, ICarDal
    {
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            using (ReCapProjectDBContext reCapProjectDBContext=new ReCapProjectDBContext())
            {
                var result = from car in reCapProjectDBContext.Cars
                             join brand in reCapProjectDBContext.Brands
                             on car.BrandId equals brand.Id
                             join color in reCapProjectDBContext.Colors
                             on car.ColorId equals color.Id
                             select new CarDetailDto
                             {
                                 CarId = car.Id,
                                 DailyPrice = car.DailyPrice,
                                 ColorName = color.ColorName,
                                 BrandName = brand.BrandName
                             };
                return new SuccessDataResult<List<CarDetailDto>>(result.ToList());
                           
            }
        }
    }
}
