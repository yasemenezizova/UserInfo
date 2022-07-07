using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProcess.Data.Abstract;
using UserProcess.Data.Concrete.Contexts;
using UserProcess.Data.Concrete.Repositories;

namespace UserProcess.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly UserProcessContext _context;
        private EfAddressRepository _addressRepository;
        private EfPersonRepository _personRepository;

        public UnitOfWork(UserProcessContext context)
        {
            _context = context;
        }


        public IAddressRepository Adresses => _addressRepository ?? new EfAddressRepository(_context);

        public IPersonRepository Person => _personRepository ?? new EfPersonRepository(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
           
        }
    }
}
