using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradify.Core.Models
{
    public class Semester
    {
        public string SemesterName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<RegistrationArchive> RegistrationArchives { get; set; }
        public ICollection<Registration> Registrations { get; set; }
        public ICollection<SemesterCourseSettings> SemesterCourseSettings { get; set; }
    }

}
