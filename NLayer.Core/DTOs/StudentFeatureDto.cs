using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class StudentFeatureDto:BaseDto
    {
        public double Size { get; set; }
        public double Weight { get; set; }
        public int StudentId { get; set; }
    }
}
