using CourseStor.Model.Framework;
using CourseStor.Model.Tags.Commands;
using CourseStore.BLL.Framwork;
using CourseStore.DAL.Context;
using CourseStore.DAL.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CourseStore.BLL.Tags.Commands;

public class UpdateTagHandler : BaseApplicationsServiceHandler<UpdateTag, Tag>
{
    public UpdateTagHandler(ContextStoreDbContext context) : base(context)
    {
    }

    protected override async Task HandleRequest(UpdateTag request, CancellationToken cancellationToken)
    {
        var qTag = await _context.Tags.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (qTag is null)
            AddError($"تگ با شناسه {request.Id} یافت نشد");
        else
        {
            qTag.TagName = request.TagName;
            await _context.SaveChangesAsync(cancellationToken);
            AddResult(qTag);
        }
    }
}
