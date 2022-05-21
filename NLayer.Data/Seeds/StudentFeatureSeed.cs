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
    internal class StudentFeatureSeed : IEntityTypeConfiguration<Core.Models.StudentFeature>
    {
        public void Configure(EntityTypeBuilder<Core.Models.StudentFeature> builder)
        {
            builder.HasData(
                new Core.Models.StudentFeature
                {
                    Id = 1,
                    Size = 170,
                    Weight = 65,
                    StudentId = 1,
                },
                new Core.Models.StudentFeature
                {
                    Id = 2,
                    Size = 165,
                    Weight = 60,
                    StudentId= 3,
                },
                new Core.Models.StudentFeature
                {
                    Id = 3,
                    Size = 159,
                    Weight = 55,
                    StudentId = 2,
                },
                new Core.Models.StudentFeature
                {
                    Id = 4,
                    Size = 150,
                    Weight = 45,
                    StudentId = 4,
                }
            );
        }
    }
}
