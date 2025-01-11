using CourseStor.Model.Framework;
using CourseStor.Model.Tags.Dtos;
using MediatR;

namespace CourseStor.Model.Tags.Queries
{
    public class FilterByName : IRequest<ApplicationServiceResponse<List<TagQr>>>
    {
        public string? TagName { get; set; }
    }
}
