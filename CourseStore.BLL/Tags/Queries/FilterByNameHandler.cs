using CourseStor.Model.Tags.Dtos;
using CourseStor.Model.Tags.Queries;
using CourseStore.BLL.Framwork;
using CourseStore.DAL.Context;
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
            var tags = _context.Tags.AsQueryable();

            if (!string.IsNullOrEmpty(request.TagName))
            {
                tags = tags.Where(p => p.TagName.Contains(request.TagName));
            }

            var result = await tags.Select(c => new TagQr
            {
                Id = c.Id,
                TagName = c.TagName
            }).ToListAsync(cancellationToken);

            AddResult(result);
        }
    }
}
