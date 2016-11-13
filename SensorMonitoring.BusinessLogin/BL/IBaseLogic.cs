using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensorMonitoring.BusinessLogin.SensorServiceReference1;
using SensorMonitoring.Data.DTO;

namespace SensorMonitoring.BusinessLogin.BL
{
    public interface IBaseLogic<T> where T : IModelDto
    {
        T Get(object[] keys);
        void Create(T item);
        void Update(T item);
        void Delete(object[] keys);
    }
}
