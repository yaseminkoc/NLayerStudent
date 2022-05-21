using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    public class StudentFeature
    {
        public int Id { get; set; }
        public double Size { get; set; }
        public double Weight { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }

    }
}
