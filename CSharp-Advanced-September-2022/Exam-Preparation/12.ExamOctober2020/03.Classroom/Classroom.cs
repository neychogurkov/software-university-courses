using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            this.students = new List<Student>();
            this.Capacity = capacity;
        }

        public int Capacity { get; set; }
        public int Count => this.students.Count;

        public string RegisterStudent(Student student)
        {
            if (this.Count < this.Capacity)
            {
                this.students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = GetStudent(firstName, lastName);

            if (student != null)
            {
                this.students.Remove(student);
                return $"Dismissed student {firstName} {lastName}";
            }
            else
            {
                return "Student not found";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> students = this.students.Where(s => s.Subject == subject).ToList();

            if (students.Count == 0)
            {
                return "No students enrolled for the subject";
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");

            foreach (var student in students)
            {
                sb.AppendLine($"{student.FirstName} {student.LastName}");
            }

            return sb.ToString().TrimEnd();
        }

        public int GetStudentsCount() => this.Count;

        public Student GetStudent(string firstName, string lastName) => this.students.Find(s => s.FirstName == firstName && s.LastName == lastName);
    }
}
