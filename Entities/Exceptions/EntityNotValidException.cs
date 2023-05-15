using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class EntityNotValidException<T> : Exception
    {
        public EntityNotValidException() : base($"{typeof(T).Name} is not valid"){ }
    }
}
