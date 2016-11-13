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
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "SensorReadingService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы SensorReadingService.svc или SensorReadingService.svc.cs в обозревателе решений и начните отладку.
    public class SensorReadingService : IDataService<SensorReadingDto>
    {
        private IRepository<SensorReading> repo = new Repository<SensorReading>();
        public SensorReadingDto GetItem(object[] keys)
        {
            return new SensorReadingDto(repo.Get(keys));
        }

        public IEnumerable<SensorReadingDto> Get()
        {
            return repo.Get().Select(s => new SensorReadingDto(s));
        }

        public void AddItem(SensorReadingDto sensor)
        {
            repo.Add(sensor.ToEntity());
        }

        public void UpdateItem(SensorReadingDto sensor)
        {
            repo.Update(sensor.ToEntity());
        }
    }
}
