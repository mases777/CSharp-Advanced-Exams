using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Classroom
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private string subject;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        public Student(string firstName, string lastName, string subject)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Subject = subject;
        }
        public override string ToString()
        {
            return $"Student: First Name = {this.FirstName}, Last Name = {this.LastName}, Subject = {this.Subject}";
        }
    }
}
