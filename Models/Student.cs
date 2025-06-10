using System;

namespace StudentGradeApp.Models
{
    public class Student
    {
        public int Id { get; set; } 
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public string Grupa { get; set; }
    }
}