using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    public class ProjectFeature
    {
        public int Id { get; set; }
        public string LessonName { get; set; }
        public string Content { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }

    }
}
