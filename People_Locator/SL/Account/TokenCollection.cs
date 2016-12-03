using BLL.Loader;
using BLL.Loader.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SL.Account
{
    static class TokenCollection
    {
        private static string key = Guid.NewGuid().ToString();

        public static string GenerateToken(UserDTO user)
        {
            return TripleEncryptor.Encrypt(user.Email, key);
        }

        public static UserDTO GetByToken(string token)
        {
            string login = TripleEncryptor.Decrypt(token, key);

            ILoader<UserDTO> loader = DependencyResolver.Current.GetService<ILoader<UserDTO>>();

            return loader.LoadAll().First(user => user.Email == login);
        }

    }
}
