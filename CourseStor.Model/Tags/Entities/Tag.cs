using CourseStor.Model.Courses.Entities;
using CourseStor.Model.Framework;

namespace CourseStore.DAL.Entities;

public class Tag : BaseEntities
{
    public string TagName { get; set; }

    public List<CourseTag> CourseTags { get; set; }
}