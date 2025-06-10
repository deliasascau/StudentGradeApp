using System;

namespace StudentGradeApp.Models
{
    public enum TipEvaluare {
        None = 0,    // asta previne erorile când JSON-ul conține 0
        Examen = 1, Colocviu = 2 }

    public class Disciplina
    {
        public int Id { get; set; } 
        public string Nume { get; set; }
        public string Acronym { get; set; }
        public TipEvaluare TipEvaluare { get; set; }
    }
}