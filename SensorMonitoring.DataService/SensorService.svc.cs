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
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "SensorService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы SensorService.svc или SensorService.svc.cs в обозревателе решений и начните отладку.
    public class SensorService : IDataService<SensorDto>
    {
        private IRepository<Sensor> repo = new Repository<Sensor>();
        public SensorDto GetItem(object[] keys)
        {
            return new SensorDto(repo.Get(keys));
        }

        public IEnumerable<SensorDto> Get()
        {
            return repo.Get().Select(s => new SensorDto(s));
        }

        public void AddItem(SensorDto sensor)
        {
            repo.Add(sensor.ToEntity());
        }

        public void UpdateItem(SensorDto sensor)
        {
            repo.Update(sensor.ToEntity());
        }
    }
}
