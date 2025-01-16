using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseStor.Model.Courses.Commands;
using CourseStore.BLL.Framwork;
using CourseStore.DAL.Context;
using CourseStore.DAL.Entities;
using MediatR;

namespace CourseStore.BLL.Courses.Commands
{
    public class CreateCourseHander : BaseApplicationsServiceHandler<CreateCourse, Course>
    {
        public CreateCourseHander(ContextStoreDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(CreateCourse request, CancellationToken cancellationToken)
        {
            Course course = new()
            {
                Title = request.Title,
                Price = request.Price,
                ImageUrl = request.ImageUrl,
                shortDescription = request.shortDescription,
                Description = request.Description
            };

            await _context.Courses.AddAsync(course, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            AddResult(course);
        }
    }
}
