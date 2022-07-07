using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProcess.Shared.Entities.Abstract;

namespace UserProcess.Entity.Concrete
{
    public class Person:EntityBase,IEntity
    {
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public long? AddressId { get; set; }
		public virtual Address Address { get; set; }
	}
}
