using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class EntityNotFoundException<T> : NotFoundException  
    {
        public EntityNotFoundException() : base($"{typeof(T).Name} does not exist in database")
        {

        } 
    }
}
