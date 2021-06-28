using backend.Data.EmployeeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data
{
    public class MockUnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        public IEmployeeData IEmployee { get; set; }

        public MockUnitOfWork(DatabaseContext context, IEmployeeData employeeData)
        {
            _context = context;
            IEmployee = employeeData;
        }
        public async Task<bool> Complete()
        {
            var save = await _context.SaveChangesAsync();

            if (save == 1)
                return true;
            else return false;
        }
    }
}
