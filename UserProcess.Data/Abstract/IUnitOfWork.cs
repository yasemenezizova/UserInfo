using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProcess.Data.Abstract
{
    public interface IUnitOfWork: IAsyncDisposable
    {
        IAddressRepository Adresses { get;  }
        IPersonRepository Person { get; }
        Task<int> SaveAsync();
    }
}
