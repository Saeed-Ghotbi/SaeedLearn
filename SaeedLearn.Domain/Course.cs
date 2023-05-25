using SaeedLearn.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaeedLearn.Domain
{
    public class Course : BaseDomainEntity
    {
        public string Description { get; set; }
        public DateTime DateModified { get; set; }
        public string? ImgPath { get; set; }
        public Teacher Teacher { get; set; }
        public bool ActiveCourse { get; set; }
        public double Price { get; set; }
        public float? Offer { get; set; }
        public int TeacherId { get; set; }
        public int CategoryId { get; set; }

    }
}
