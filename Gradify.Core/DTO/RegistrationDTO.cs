using Gradify.Core.Enums;
using Gradify.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradify.Core.DTO
{
    public class RegistrationDTO
    {
        [Required]
        public string SemesterName { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public string CourseCode { get; set; }
    }
}
