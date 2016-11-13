using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SensorMonitoring.Data.DTO;
using SensorMonitoring.Data.Models;

namespace SensorMonitoring.DataService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IDataService<T> where T : IModelDto
    {

        [OperationContract]
        T GetItem(object[] keys);

        [OperationContract]
        IEnumerable<T> Get();

        [OperationContract]
        void UpdateItem(T item);

        [OperationContract]
        void AddItem(T item);

        //[OperationContract]
    }
}
