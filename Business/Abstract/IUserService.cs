using Core.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IDataResult<User> GetById(int userId);
        IDataResult<User> GetByFirstName(string firstName);
        IDataResult<User> GetByLastName(string lastName);
        IDataResult<List<User>> GetAll();
    }
}
