using BLL.Loader.DTO;
using System;
using DevOne.Security.Cryptography.BCrypt;
using System.Linq;
using BLL.Validation;
using Newtonsoft.Json;

namespace BLL.Services
{
    internal class UserService : BaseService<UserDTO>, IUserService
    {
        public UserDTO Login(string login, string password)
        {
            UserDTO user = this.Find(u => u.Email == login).First();

            if (BCryptHelper.CheckPassword(password, user.Password))
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public void Register(UserDTO user)
        {
            if (!validator.CanCreate(user))
            {
                throw new ValidationException($"Cannot add to database next entity '{ JsonConvert.SerializeObject(user) }'");
            }
            user.Password = BCryptHelper.HashPassword(user.Password, BCryptHelper.GenerateSalt());

            CUDResponseView result = loader.PostItem(user);

            if (!result.IsSuccess)
            {
                throw new DALException("error after post request");
            }
        }

        public new void Create(UserDTO item)
        {
            throw new InvalidOperationException("creating users possible just throw register method");
        }

        public new void Update(UserDTO user)
        {
            if (!validator.CanUpdate(user))
            {
                throw new ValidationException($"Cannot add to database next entity '{ JsonConvert.SerializeObject(user) }'");
            }

            user.Password = BCryptHelper.HashPassword(user.Password, BCryptHelper.GenerateSalt());

            CUDResponseView result = loader.PutItem(user);

            if (!result.IsSuccess)
            {
                throw new DALException("error after put request");
            }
        }

    }
}
