using CourseStor.Model.Framework;

namespace CourseStore.DAL.Entities;

public class CourseTeacher : BaseEntities
{
    public Teacher Teachers { get; set; }

    public Course Course { get; set; }

    public int TeacherId { get; set; }

    public int CourseId { get; set; }

    public int SortOrder { get; set; }
}