using Gradify.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradify.Core.Responses
{
    public class ExamResponse
    {
        public string Name { get; set; }
        public double DisplayMarks { get; set; }
        public double RealMarks { get; set; }
        public bool IsAbsent { get; set; }
        public bool IsSame { get; set; }
    }
}
