using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorMonitoring.BusinessLogin.Services
{
    public interface IUserService : IService<UserDTO>
    {
        UserDTO Login(string login, string password);
        void Register(UserDTO user);
    }
}
