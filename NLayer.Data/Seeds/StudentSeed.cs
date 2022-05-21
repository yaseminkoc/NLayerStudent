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
    internal class StudentSeed : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasData(
                new Student { Id = 1, Name = "Yasemin", Surname = "KOÇ" },
                new Student { Id = 2, Name = "Yasin", Surname = "SELEK" },
                new Student { Id = 3, Name = "Betül", Surname = "YILMAZ" }
            );
        }
    }
}
