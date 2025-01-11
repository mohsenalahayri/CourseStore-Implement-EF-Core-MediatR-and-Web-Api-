using System.ComponentModel.DataAnnotations;
using CourseStor.Model.Framework;
using CourseStore.DAL.Entities;
using MediatR;

namespace CourseStor.Model.Tags.Commands;

public class CreateTag : IRequest<ApplicationServiceResponse<Tag>>
{
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string TagName { get; set; }
}