using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaeedLearn.Application.DTOs.Common
{
    public class BaseDto
    {
        public int    Id          { get; set; }
        public string Title       { get; set; }
        public double Price       { get; set; }
        public float? Offer       { get; set; }
        public string TeacherName { get; set; }
    }
}
