using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradify.Core.Models
{
    public class Course
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int CreditHrs { get; set; }

        public ICollection<RegistrationArchive> RegistrationArchives { get; set; }
        public ICollection<Registration> Registrations { get; set; }
        public ICollection<SemesterCourseSettings> SemesterCourseSettings { get; set; }
    }

}
