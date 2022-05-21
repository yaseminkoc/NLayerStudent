using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Configurations
{
    internal class StudentFeatureConfiguration : IEntityTypeConfiguration<StudentFeature>
    {
        public void Configure(EntityTypeBuilder<StudentFeature> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Student).WithOne(x => x.StudentFeature).HasForeignKey<StudentFeature>(x => x.StudentId);
            builder.ToTable("StudentFeatures");
        }
    }
}
