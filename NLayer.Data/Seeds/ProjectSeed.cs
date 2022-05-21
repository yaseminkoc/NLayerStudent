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
    internal class ProjectSeed : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasData(
                new Project { Id = 1, Name = "Çevre Teknolojileri", Grade = 90, StudentId = 1, CreatedDate = DateTime.Now },
                new Project { Id = 2, Name = "Yapay Zeka", Grade = 100, StudentId = 1, CreatedDate = DateTime.Now },
                new Project { Id = 3, Name = "Enerji Verimliliği", Grade = 85, StudentId = 2, CreatedDate = DateTime.Now },
                new Project { Id = 4, Name = "Serbest Kanat İHA", Grade = 100, StudentId = 3, CreatedDate = DateTime.Now }
            );
        }
    }
}
