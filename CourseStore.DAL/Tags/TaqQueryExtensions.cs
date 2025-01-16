using CourseStor.Model.Tags.Dtos;
using CourseStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseStore.DAL.Tags
{
    public static class TaqQueryExtensions
    {
        public static IQueryable<Tag> WhereOver(this IQueryable<Tag> tags, string tagName)
        {
            if (!string.IsNullOrEmpty(tagName))
                tags = tags.Where(p => p.TagName.Contains(tagName));

            return tags;
        }

        public static async Task<List<TagQr>> ToTagQrsAsync(this IQueryable<Tag> tags, CancellationToken cancellationToken)
        {
            return await tags.Select(p => new TagQr
            {
                TagName = p.TagName,
                Id = p.Id
            }).ToListAsync(cancellationToken);
        }
    }
}
