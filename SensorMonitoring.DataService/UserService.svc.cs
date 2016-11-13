using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SensorMonitoring.Data.DAL;
using SensorMonitoring.Data.DTO;
using SensorMonitoring.Data.Models;

namespace SensorMonitoring.DataService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "UserService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы UserService.svc или UserService.svc.cs в обозревателе решений и начните отладку.
    public class UserService : IDataService<UserDto>
    {
        private IRepository<User> repo = new Repository<User>();
        public UserDto GetItem(object[] keys)
        {
            return new UserDto(repo.Get(keys));
        }

        public IEnumerable<UserDto> Get()
        {
            return repo.Get().Select(u => new UserDto(u));
        }

        public void AddItem(UserDto sensor)
        {
            repo.Add(sensor.ToEntity());
        }

        public void UpdateItem(UserDto sensor)
        {
            repo.Update(sensor.ToEntity());
        }
        public void DoWork()
        {
        }
    }
}
