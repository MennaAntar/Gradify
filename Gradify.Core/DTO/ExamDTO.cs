using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradify.Core.DTO
{
    public class ExamDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double DisplayMarks { get; set; }
        [Required]
        public double RealMarks { get; set; }
        [Required]
        public bool IsSame { get; set; }
    }
}
