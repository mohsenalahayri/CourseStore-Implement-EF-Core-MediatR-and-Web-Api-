using CourseStor.Model.Framework;

namespace CourseStore.DAL.Entities;

public class CourseComment : BaseEntities
{
    public int CourseId { get; set; }

    public Course Course { get; set; }

    public string CommentBy { get; set; }

    public DateTime CommentDate { get; set; }

    public bool IsValid { get; set; }

    public string Comment { get; set; }
}