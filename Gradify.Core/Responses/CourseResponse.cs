using Gradify.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradify.Core.Responses
{
    public class CourseResponse
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int CreditHrs { get; set; }
    }
}
