using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAllUser();
        IDataResult<User> GetUserById(int userId);
        IDataResult<User> CheckUser(string email, string password);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
    }
}
