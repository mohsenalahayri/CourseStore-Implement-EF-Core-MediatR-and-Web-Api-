﻿using System.ComponentModel.DataAnnotations;
using CourseStor.Model.Framework;
using CourseStore.DAL.Entities;
using MediatR;

namespace CourseStor.Model.Tags.Commands;

public class UpdateTag : IRequest<ApplicationServiceResponse<Tag>>
{
    [Required]
    [Range(1, int.MaxValue)]
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string TagName { get; set; } = string.Empty;
}