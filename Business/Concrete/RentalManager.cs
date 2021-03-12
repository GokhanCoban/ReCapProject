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
            var result= new  SuccessDataResult<List<Rental>>(_rentalDal.GetAll());

            if (result.Success)
            {
                return new SuccessDataResult<List<Rental>>(result.Data);
            }

            return new ErrorDataResult<List<Rental>>(result.Message);
        }

        public IDataResult<Rental> GetById(int id)
        {
           var result=  _rentalDal.Get(r=> r.Id==id);
            if (result!=null)
            {
                return new SuccessDataResult<Rental>(result);
            }

            return new ErrorDataResult<Rental>(Messages.TheRentalNotFound);
         
        }

        public IResult Update(Rental rental)
        {
            if (rental!=null)
            {
                _rentalDal.Update(rental);

                return new SuccessResult(Messages.TheCustomerUpdated);
            }

            return new ErrorResult(Messages.TheCustomerUpdatedError);
        }
    }
}
