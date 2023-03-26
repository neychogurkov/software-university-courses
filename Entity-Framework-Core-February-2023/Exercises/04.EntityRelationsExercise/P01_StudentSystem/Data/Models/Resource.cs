namespace P01_StudentSystem.Data.Models;

using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

using Enums;

public class Resource
{
    public int ResourceId { get; set; }

    [MaxLength(50)]
    [Unicode(true)]
    public string Name { get; set; } = null!;

    [Unicode(false)]
    public string Url { get; set; } = null!;

    public ResourceType ResourceType { get; set; }

    public int CourseId { get; set; }
    public virtual Course Course { get; set; } = null!;
}