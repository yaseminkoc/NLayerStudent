using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    internal class SchoolSeed : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.HasData(
                new School { Id = 1, Name = "MCBÜ", NumberOfStudents = 35000, CreatedDate = DateTime.Now },
                new School { Id = 2, Name = "MASKÜ", NumberOfStudents = 35000, CreatedDate = DateTime.Now },
                new School { Id = 3, Name = "EGE", NumberOfStudents = 65000, CreatedDate = DateTime.Now },
                new School { Id = 4, Name = "SAÜ", NumberOfStudents = 45000, CreatedDate = DateTime.Now }
            );
        }
    }
}
