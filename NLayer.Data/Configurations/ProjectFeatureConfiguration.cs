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
    internal class ProjectFeatureConfiguration : IEntityTypeConfiguration<ProjectFeature>
    {
        public void Configure(EntityTypeBuilder<ProjectFeature> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Project).WithOne(x => x.ProjectFeature).HasForeignKey<ProjectFeature>(x => x.ProjectId);
            builder.ToTable("ProjectFeatures");
        }
    }
}
