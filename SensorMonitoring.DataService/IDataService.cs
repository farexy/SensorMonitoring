using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SensorMonitoring.Data.Models;

namespace SensorMonitoring.DataService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IDataService
    {

        [OperationContract]
        IModel GetItem(object[] keys);

        [OperationContract]
        IModelDto GetDataUsingDataContract(IModelDto       composite);

        // TODO: Добавьте здесь операции служб
    }


    
}
