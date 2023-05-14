using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class EntityUnotharizeException<T> : Exception
    {
        public EntityUnotharizeException() : base($"{typeof(T).Name} is unotharize")
        {

        }
    }
}
