using System;

namespace StudentGradeApp.Models
{
    public class Nota
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int DisciplinaId { get; set; }
        public int Valoare { get; set; }
        public DateTime DataNota { get; set; } = DateTime.Now;
    }
}