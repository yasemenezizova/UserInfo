using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProcess.Data.Abstract;
using UserProcess.Entity.Concrete;
using UserProcess.Shared.Data.Concrete.EntityFramework;

namespace UserProcess.Data.Concrete.Repositories
{
    public class EfPersonRepository : EfEntityRepositoryBase<Person>, IPersonRepository
    {
        public EfPersonRepository(DbContext context) : base(context)
        {
        }
    }
}
