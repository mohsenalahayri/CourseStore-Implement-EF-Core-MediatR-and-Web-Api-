using CourseStor.Model.Tags.Dtos;
using CourseStor.Model.Tags.Queries;
using CourseStore.BLL.Framwork;
using CourseStore.DAL.Context;
using CourseStore.DAL.Tags;
using Microsoft.EntityFrameworkCore;

namespace CourseStore.BLL.Tags.Queries
{
    public class FilterByNameHandler : BaseApplicationsServiceHandler<FilterByName, List<TagQr>>
    {
        public FilterByNameHandler(ContextStoreDbContext context) : base(context)
        {
        }

        protected override async Task HandleRequest(FilterByName request, CancellationToken cancellationToken)
        {
            var tags = await _context.Tags.WhereOver(request.TagName).ToTagQrsAsync(cancellationToken);

            AddResult(tags);
        }
    }
}
