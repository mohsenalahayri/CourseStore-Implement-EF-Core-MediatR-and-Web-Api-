using System.Xml.Linq;
using CourseStor.Model.Courses.Entities;
using CourseStor.Model.Framework;

namespace CourseStore.DAL.Entities;

public class Course : BaseEntities
{
    public string Title { get; set; }

    public string shortDescription { get; set; }

    public string Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int Price { get; set; }

    public string ImageUrl { get; set; }

    public List<CourseTag> CourseTags { get; set; }

    public List<CourseTeacher> CourseTeachers { get; set; }

    public List<CourseComment> CourseComments { get; set; }
}