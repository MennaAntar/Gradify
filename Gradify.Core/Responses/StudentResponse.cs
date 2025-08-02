using Gradify.Core.Enums;
using Gradify.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradify.Core.Responses
{
    public class StudentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double CGPA { get; set; }
        public int NetHrs { get; set; }
        public int CurrentPoints { get; set; }
        public DateTime LastCalculationDate { get; set; }
        public string Status { get; set; }
    }
}
