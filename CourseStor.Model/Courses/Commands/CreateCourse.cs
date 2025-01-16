using CourseStor.Model.Framework;
using CourseStore.DAL.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CourseStor.Model.Courses.Commands
{
    public class CreateCourse : IRequest<ApplicationServiceResponse<Course>>
    {
        [Required(ErrorMessage = "لطفا {0} وارد کنید")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters.")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [StringLength(5000, ErrorMessage = "لطفا {0} وارد کنید")]
        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "لطفا {0} وارد کنید")]
        [Display(Name = "مبلغ آموزش")]
        public int Price { get; set; }

        [StringLength(255, ErrorMessage = "لطفا {0} وارد کنید")]
        [Display(Name = "توضحیحات مختصر")]
        public string shortDescription { get; set; }

        [Required(ErrorMessage = "لطفا {0} وارد کنید")]
        [Display(Name = "تصویر")]
        public string ImageUrl { get; set; }
    }
}
