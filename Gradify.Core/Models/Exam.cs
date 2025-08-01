using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradify.Core.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double DisplayMarks { get; set; }
        public double RealMarks { get; set; }
        public bool IsAbsent { get; set; }
        public bool IsSame { get; set; }

        public int? RegistrationID { get; set; }
        public int? RegistrationAID { get; set; }

        public RegistrationArchive RegistrationArchive { get; set; }
        public Registration Registration { get; set; }
    }

}
