using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class EntityBadRequestException<T> : Exception
    {
        public EntityBadRequestException() : base($"{typeof(T)} object is null") { }
    }
}
