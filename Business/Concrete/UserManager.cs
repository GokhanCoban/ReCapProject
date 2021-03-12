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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            foreach (var item in _userDal.GetAll())
            {
                if (item.Email==user.Email)
                {
                    return new ErrorResult(Messages.UserAddedError);
                }
            }
           
            _userDal.Add(user);

            return new SuccessResult(Messages.UserAdded);
        }

        public IDataResult<List<User>> GetAll()
        {
            var result= new SuccessDataResult<List<User>>(_userDal.GetAll());
            if (result.Success)
            {
                return new SuccessDataResult<List<User>>(result.Data);
            }

            return new ErrorDataResult<List<User>>(Messages.UserListedError);
        }

        public IDataResult<User> GetById(int id)
        {
            var result = _userDal.Get(u=>u.Id==id);
            if (result!=null)
            {
                return new SuccessDataResult<User>(result);
            }

            return new ErrorDataResult<User>(Messages.UserNotFound);
        }

        public IResult Update(User user)
        {
            if (user!=null)
            {
                _userDal.Update(user);
                return new SuccessResult(Messages.UserUpdated);
            }

            return new ErrorResult(Messages.UserUpdatedError);
             
        }
    }
}
