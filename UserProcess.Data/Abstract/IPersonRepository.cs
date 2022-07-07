using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProcess.Entity.Concrete;
using UserProcess.Shared.Data.Abstract;

namespace UserProcess.Data.Abstract
{
    public interface IPersonRepository : IEntityRepository<Person>
    {
    }
}
