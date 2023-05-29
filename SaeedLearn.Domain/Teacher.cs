using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaeedLearn.Domain.Common;

namespace SaeedLearn.Domain
{
    public class Teacher : BaseDomainEntity
    {
        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}
