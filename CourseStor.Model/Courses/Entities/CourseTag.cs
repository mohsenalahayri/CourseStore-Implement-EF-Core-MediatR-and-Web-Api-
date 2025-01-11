using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseStor.Model.Framework;
using CourseStore.DAL.Entities;

namespace CourseStor.Model.Courses.Entities
{
    public class CourseTag : BaseEntities
    {
        public int CourseId { get; set; }
        public int TagId { get; set; }

        public Course Course { get; set; }

        public Tag Tag { get; set; }
    }
}
