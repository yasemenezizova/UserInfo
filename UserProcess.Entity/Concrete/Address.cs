using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProcess.Shared.Entities.Abstract;

namespace UserProcess.Entity.Concrete
{
    public class Address:EntityBase,IEntity
    {
        public string City { get; set; }
        public string AddressLine { get; set; }
        public virtual Person Person { get; set; }

    }
}
