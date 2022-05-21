using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    public class Project : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public ProjectFeature ProjectFeature { get; set; }
    }
}
