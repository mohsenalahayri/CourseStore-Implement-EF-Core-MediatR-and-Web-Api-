using CourseStor.Model.Courses.Commands;
using CourseStore.WebAPI.Framework;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseStore.WebAPI.Courses
{
    public class CoursesController : BaseController
    {
        public CoursesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateCours([FromQuery] CreateCourse course)
        {
            var response = await _mediator.Send(course);

            return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
        }
    }
}