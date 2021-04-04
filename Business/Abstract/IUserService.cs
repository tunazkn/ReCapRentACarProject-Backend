using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IResult UpdateProfile(User user, string password);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int userId);

        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByEmail(string email);

        IDataResult<Findeks> GetUserFindeks(Findeks findeks);
    }
}
