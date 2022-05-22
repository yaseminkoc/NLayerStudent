using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class SchoolRepository : GenericRepository<School>, ISchoolRepository
    {
        public SchoolRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<School> GetSingleSchoolByIdWithStudentsAsync(int schoolId)
        {
            return await _context.Schools.Include(x => x.Students).Where(x => x.Id == schoolId).SingleOrDefaultAsync();
        }
    }
}
