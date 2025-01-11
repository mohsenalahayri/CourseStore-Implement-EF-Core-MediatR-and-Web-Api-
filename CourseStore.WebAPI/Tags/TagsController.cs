using CourseStor.Model.Tags.Commands;
using CourseStor.Model.Tags.Queries;
using CourseStore.DAL.Entities;
using CourseStore.WebAPI.Framework;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseStore.WebAPI.Tags;

[Route("[controller]")]
[ApiController]
public class TagsController : BaseController
{
    public TagsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> CreateTag(CreateTag tag)
    {
        var response = await _mediator.Send(tag);

        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
    }

    [HttpPut("UpdateTag")]
    public async Task<IActionResult> UpdateTag(UpdateTag tag)
    {
        var response = await _mediator.Send(tag);

        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
    }

    [HttpGet("FilterByName")]
    public async Task<IActionResult> SearchTag([FromQuery] FilterByName byName)
    {
        var response = await _mediator.Send(byName);

        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
    }
}
