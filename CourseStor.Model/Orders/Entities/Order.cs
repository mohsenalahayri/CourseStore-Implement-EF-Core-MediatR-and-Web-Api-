using CourseStor.Model.Framework;

namespace CourseStore.DAL.Entities;

public class Order : BaseEntities
{
    public int CourseId { get; set; }

    public Course Course { get; set; }

    public DateTime OrderDate { get; set; }

    public string CustomerEmail { get; set; }

    public int Price { get; set; }
}