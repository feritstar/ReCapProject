using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Results;
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

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            var query = _userDal.Get(u => u.Id == user.Id);
            _userDal.Delete(query);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
        }

        public IDataResult<User> GetByFirstName(string firstName)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<User>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<User>(_userDal.Get(u => u.FirstName == firstName), Messages.UserListed);
        }

        public IDataResult<User> GetById(int userId)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<User>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId), Messages.UserListed);
        }

        public IDataResult<User> GetByLastName(string lastName)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<User>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<User>(_userDal.Get(u => u.LastName == lastName), Messages.UserListed);
        }

        public IResult Update(User user)
        {
            var query = _userDal.Get(u => u.Id == user.Id);
            query.FirstName = user.FirstName;
            query.LastName = user.LastName;
            query.EmailAddress = user.EmailAddress;
            query.Password = user.Password;
            _userDal.Update(query);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
