using CourseStor.Model.Framework;
using CourseStore.DAL.Context;
using MediatR;

namespace CourseStore.BLL.Framwork;
public abstract class BaseApplicationsServiceHandler<TRequest, TResult> : IRequestHandler<TRequest, ApplicationServiceResponse<TResult>>
    where TRequest : IRequest<ApplicationServiceResponse<TResult>>
{
    protected readonly ContextStoreDbContext _context;

    protected ApplicationServiceResponse<TResult> _response = new ApplicationServiceResponse<TResult>() { };

    public BaseApplicationsServiceHandler(ContextStoreDbContext context) => _context = context;

    public async Task<ApplicationServiceResponse<TResult>> Handle(TRequest request, CancellationToken cancellationToken)
    {
        await HandleRequest(request, cancellationToken);
        return _response;
    }

    protected abstract Task HandleRequest(TRequest request, CancellationToken cancellationToken);

    public void AddError(string error)
    {
        _response.AddError(error);
    }

    public void AddResult(TResult result)
    {
        _response.Result = result;
    }
}