namespace P01_StudentSystem.Data.Models;

using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

public class Course
{
    public Course()
    {
        this.Resources = new HashSet<Resource>();
        this.Homeworks = new HashSet<Homework>();
        this.StudentsCourses = new HashSet<StudentCourse>();
    }

    public int CourseId { get; set; }

    [MaxLength(80)]
    [Unicode(true)]
    public string Name { get; set; } = null!;

    [Unicode(true)]
    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<Resource> Resources { get; set; }

    public virtual ICollection<Homework> Homeworks { get; set; }

    public virtual ICollection<StudentCourse> StudentsCourses { get; set; }
}