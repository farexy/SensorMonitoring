using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Loader.DTO
{
    public abstract class BaseDTO
    {
        internal BaseDTO() { }

        internal abstract string pathToActions { get; }
    }
}
