using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Classroom
{
    public class Classroom
    {
        private List<Student> students;
        private int capacity;
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public int Count
        {
            get
            {
                return students.Count;
            }
            private set { }
        }
        public Classroom(int capacity)
        {
            students = new List<Student>();
            this.Capacity = capacity;
        }
        public string RegisterStudent(Student student)
        {
            if (students.Count < Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else return "No seats in the classroom";
        }
        public string DismissStudent(string firstName, string lastName)
        {
            Student removeStudent = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            if (removeStudent != null)
            {
                students.Remove(removeStudent);
                return $"Dismissed student {firstName} {lastName}";
            }
            else return "Student not found";
        }
        public string GetSubjectInfo(string subject)
        {
            StringBuilder sb = new StringBuilder();
            List<Student> studentSubject = students.Where(x => x.Subject == subject).ToList();
            if (studentSubject.Count != 0)
            {
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");
                foreach (var item in studentSubject)
                {
                    sb.AppendLine($"{item.FirstName} {item.LastName}");
                }
            }
            else sb.AppendLine("No students enrolled for the subject");
            return sb.ToString().TrimEnd();
        }
        public int GetStudentsCount()
        {
            return students.Count;
        }
        public Student GetStudent(string firstName, string lastName)
        {
            Student getStudent = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            return getStudent;
        }
    }
}
