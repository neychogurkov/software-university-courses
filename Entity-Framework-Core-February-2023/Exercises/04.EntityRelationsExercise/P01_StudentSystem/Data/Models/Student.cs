namespace P01_StudentSystem.Data.Models;

using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

public class Student
{
    public Student()
    {
        this.Homeworks = new HashSet<Homework>();
        this.StudentsCourses = new HashSet<StudentCourse>();
    }

    public int StudentId { get; set; }

    [MaxLength(100)]
    [Unicode(true)]
    public string Name { get; set; } = null!;

    [MaxLength(10)]
    [Unicode(false)]
    public string? PhoneNumber { get; set; }

    public DateTime RegisteredOn { get; set; }

    public DateTime? Birthday { get; set; }

    public virtual ICollection<Homework> Homeworks { get; set; }

    public virtual ICollection<StudentCourse> StudentsCourses { get; set; }
}