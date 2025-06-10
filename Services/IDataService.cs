using System;
using System.Collections.Generic;
using StudentGradeApp.Models;

namespace StudentGradeApp.Services
{
    public interface IDataService
    {
        // STUDENT
        IEnumerable<Student> GetAllStudents();
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int studentId);

        // DISCIPLINA
        IEnumerable<Disciplina> GetAllDiscipline();
        void AddDisciplina(Disciplina disciplina);
        void UpdateDisciplina(Disciplina disciplina);
        void DeleteDisciplina(int disciplinaId);

        // NOTA
        IEnumerable<Nota> GetAllNotes();
        void AddNota(Nota nota);
        void UpdateNota(Nota nota);
        void DeleteNota(int notaId);
    }
}
