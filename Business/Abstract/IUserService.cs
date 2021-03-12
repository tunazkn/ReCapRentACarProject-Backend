using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        IResult Add(User user);
        User GetByMail(string email);
        IDataResult<List<User>> GetAllUser();
        IDataResult<User> GetUserById(int userId);
        IResult Update(User user);
        IResult Delete(User user);
    }
}
