using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;


namespace Business.Concrate
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        //[ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }


        public IResult UpdateProfile(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var updatedUser = new User
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = user.Status
            };
            _userDal.Update(updatedUser);
            return new SuccessDataResult<User>(Messages.UserUpdated);
        }
        [SecuredOperation("User.Delete")]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        [CacheAspect]
        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
        }

        public IResult Update(User user)
        {
            if (user.FirstName.Length < 2)
            {
                return new ErrorResult(Messages.UserNameInvalid);
            }
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        [CacheAspect]
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<User> GetByEmail(string email)
        {
            var result = new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
            return result;
        }

        public IDataResult<Findeks> GetUserFindeks(Findeks findeks)
        {
            Random rnd = new Random();
            var userFindeks = new Findeks
            {
                Tc = findeks.Tc,
                DateYear = findeks.DateYear,
                UserFindeks = rnd.Next(0, 1900)
            };
            return new SuccessDataResult<Findeks>(userFindeks);
        }
    }
}