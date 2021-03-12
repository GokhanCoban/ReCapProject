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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {

            _customerDal.Add(customer);

            return new SuccessResult();
        }

        public IDataResult<List<Customer>> GetAll()
        {

           var result= new SuccessDataResult<List<Customer>>( _customerDal.GetAll());

            if (result.Success)
            {
                return new SuccessDataResult<List<Customer>>(result.Data, Messages.TheCustomerListed);
            }

            return new ErrorDataResult<List<Customer>>(Messages.TheCustomerListedError);
         
            
        }

        public IDataResult<List<Customer>> GetAll(int customerId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Customer> GetById(int id)
        {

            var result = _customerDal.Get(c => c.Id == id);

            if (result!=null)
            {

                return new SuccessDataResult<Customer>(result,Messages.TheCustomerListed);
            }

            return new ErrorDataResult<Customer>(Messages.TheCustomerListedError);
        }

        public IResult Update(Customer customer)
        {
            if (customer!=null)
            {
                _customerDal.Update(customer);

                return new SuccessResult(Messages.TheCustomerUpdated);
            }
            return new SuccessResult(Messages.TheCustomerUpdatedError);
        }
    }
}
