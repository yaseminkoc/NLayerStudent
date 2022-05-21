using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class SchoolDto:BaseDto
    {
        public string Name { get; set; }
        public int NumberOfStudents { get; set; }
    }
}
