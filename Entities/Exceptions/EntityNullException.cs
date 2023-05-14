using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class EntityNullException<T> : Exception
    {
        public EntityNullException() : base($"{typeof(T).Name} is null"){ }
    }
}
