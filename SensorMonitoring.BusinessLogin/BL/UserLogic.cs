using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SensorMonitoring.BusinessLogin.SensorServiceReference1;
using SensorMonitoring.BusinessLogin.UserServiceReference;
using SensorMonitoring.Data.DTO;

namespace SensorMonitoring.BusinessLogin.BL
{
    public class UserLogic : IBaseLogic<UserDto>
    {
        private UserServiceReference.DataServiceOf_UserDtoClient serviceOfUser = new DataServiceOf_UserDtoClient();

        public UserDto Get(object[] keys)
        {
            return (UserDto)serviceOfUser.GetItem(keys);
        }

        public void Create(UserDto user)
        { 
            serviceOfUser.AddItem(user);
        }

        public void Update(UserDto user)
        {
            serviceOfUser.AddItem(user);
        }

        public void Delete(object[] keys)
        {
            
        }

        public bool IsValid(string name, string password)
        {
            string decryptPassword = Encrypter.Decrypt(password);
            return true;
        }
    }
}