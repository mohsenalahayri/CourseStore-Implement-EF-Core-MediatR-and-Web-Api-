using CourseStor.Model.Tags.Commands;
using CourseStore.BLL.Framwork;
using CourseStore.DAL.Context;
using CourseStore.DAL.Entities;

namespace CourseStore.BLL.Tags.Commands;

public class CreateTagHandler : BaseApplicationsServiceHandler<CreateTag, Tag>
{
    public CreateTagHandler(ContextStoreDbContext context) : base(context)
    {
    }

    protected override async Task HandleRequest(CreateTag request, CancellationToken cancellationToken)
    {
        Tag tag = new()
        {
            TagName = request.TagName,
        };

        await _context.Tags.AddAsync(tag, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        AddResult(tag);
    }
}