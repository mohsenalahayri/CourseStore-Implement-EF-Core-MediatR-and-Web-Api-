using CourseStor.Model.Framework;

namespace CourseStore.DAL.Entities;

public class Teacher : BaseEntities
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public List<CourseTeacher> CourseTeachers { get; set; }
}