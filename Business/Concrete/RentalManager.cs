using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var results = _rentalDal.GetAll(x=> x.ReturnDate==null);

            foreach (var item in results)
            {
                if (rental.CarId == item.CarId)
                {
                    return new ErrorResult(Messages.TheCarIsAlreadyRented);
                }
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.TheCarIsRented); 
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }
    }
}
