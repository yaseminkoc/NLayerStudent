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
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Student>> GetStudentsWithSchool()
        {
            //Eager Loading // ilk başta ikisini de çekersek eager loading olur
            //Lazy loading //eğer projecte bağlı studenti daha sonra ihtiyaç olduğunda çekersek
            return await _context.Students.Include(x => x.School).ToListAsync();
        }
    }
}
