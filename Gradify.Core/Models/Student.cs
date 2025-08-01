using Gradify.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradify.Core.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double CGPA { get; set; }
        public int NetHrs { get; set; }
        public int CurrentPoints { get; set; }
        public DateTime LastCalculationDate { get; set; }
        public StudentState Status { get; set; }

        public ICollection<RegistrationArchive> RegistrationArchives { get; set; }
        public ICollection<Registration> Registrations { get; set; }
    }
}
