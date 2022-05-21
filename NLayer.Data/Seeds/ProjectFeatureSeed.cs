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
    internal class ProjectFeatureSeed : IEntityTypeConfiguration<ProjectFeature>
    {
        public void Configure(EntityTypeBuilder<ProjectFeature> builder)
        {
            builder.HasData(
                new ProjectFeature
                {
                    Id = 1,
                    LessonName = "Coğrafya",
                    Content = "Daha yaşanılabilir bir dünya için insanları bilinçlendirme çalışması yapmak",
                    ProjectId = 1,
                },
                new ProjectFeature
                {
                    Id = 2,
                    LessonName = "Machine Learning",
                    Content = "Yapay zekayı tüm dünyaya yaymak için çalışmalar yapmak.",
                    ProjectId = 2,
                },
                new ProjectFeature
                {
                    Id = 3,
                    LessonName = "Coğrafya",
                    Content = "Enerji kaynaklarımızın kullanımına yönelik çalışmalar yapmak.",
                    ProjectId = 3,
                },
                new ProjectFeature
                {
                    Id = 4,
                    LessonName = "Elektrik",
                    Content = "Kendi ihamızı kendimiz tasarlayalım konulu çalışma yapma.",
                    ProjectId = 4,
                }
            );
        }
    }
}
