using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using StudentGradeApp.Models;

namespace StudentGradeApp.Services
{
    /// <summary>
    /// Implementare a interfeței IDataService folosind fișiere JSON pentru persistență.
    /// </summary>
    public class JsonDataService : IDataService
    {
        // Căile către fișierele JSON
        private readonly string _studentsFile = "students.json";
        private readonly string _disciplineFile = "discipline.json";
        private readonly string _noteFile = "note.json";

        // ===== FUNCȚII GENERICE =====

        /// <summary>
        /// Încarcă o listă de obiecte de tip T din fișierul dat.
        /// Dacă fișierul nu există, returnează o listă goală.
        /// </summary>
        private List<T> LoadList<T>(string path)
        {
            if (!File.Exists(path))
                return new List<T>();

            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<T>>(json)
                   ?? new List<T>();
        }

        /// <summary>
        /// Salvează o listă de obiecte de tip T într-un fișier JSON.
        /// </summary>
        private void SaveList<T>(string path, List<T> list)
        {
            var json = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        // ===== STUDENT =====

        public IEnumerable<Student> GetAllStudents()
        {
            return LoadList<Student>(_studentsFile);
        }

        public void AddStudent(Student student)
        {
            var list = LoadList<Student>(_studentsFile);
            list.Add(student); // Id-ul e deja generat în StudentForm
            SaveList(_studentsFile, list);
        }

        public void UpdateStudent(Student student)
        {
            var list = LoadList<Student>(_studentsFile);
            var idx = list.FindIndex(s => s.Id == student.Id);
            if (idx >= 0)
            {
                list[idx] = student;
                SaveList(_studentsFile, list);
            }
        }

        public void DeleteStudent(int studentId)
        {
            var list = LoadList<Student>(_studentsFile);
            if (list.RemoveAll(s => s.Id == studentId) > 0)
                SaveList(_studentsFile, list);
        }

        // ===== DISCIPLINA =====

        public IEnumerable<Disciplina> GetAllDiscipline()
        {
            return LoadList<Disciplina>(_disciplineFile);
        }

        public void AddDisciplina(Disciplina disciplina)
        {
            var list = LoadList<Disciplina>(_disciplineFile);
            list.Add(disciplina); // Id-ul e setat în DisciplinaForm
            SaveList(_disciplineFile, list);
        }

        public void UpdateDisciplina(Disciplina disciplina)
        {
            var list = LoadList<Disciplina>(_disciplineFile);
            var idx = list.FindIndex(d => d.Id == disciplina.Id);
            if (idx >= 0)
            {
                list[idx] = disciplina;
                SaveList(_disciplineFile, list);
            }
        }

        public void DeleteDisciplina(int disciplinaId)
        {
            var list = LoadList<Disciplina>(_disciplineFile);
            if (list.RemoveAll(d => d.Id == disciplinaId) > 0)
                SaveList(_disciplineFile, list);
        }

        // ===== NOTA =====

        public IEnumerable<Nota> GetAllNotes()
        {
            return LoadList<Nota>(_noteFile);
        }

        public void AddNota(Nota nota)
        {
            var list = LoadList<Nota>(_noteFile);
            list.Add(nota); // Id-ul e compus în NotaForm (StudentId + DisciplinaId)
            SaveList(_noteFile, list);
        }

        public void UpdateNota(Nota nota)
        {
            var list = LoadList<Nota>(_noteFile);
            var idx = list.FindIndex(n => n.Id == nota.Id);
            if (idx >= 0)
            {
                list[idx] = nota;
                SaveList(_noteFile, list);
            }
        }

        public void DeleteNota(int notaId)
        {
            var list = LoadList<Nota>(_noteFile);
            if (list.RemoveAll(n => n.Id == notaId) > 0)
                SaveList(_noteFile, list);
        }
    }
}
