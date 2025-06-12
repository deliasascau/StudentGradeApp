using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StudentGradeApp.Utils
{
    /// <summary>
    /// Utilitar static pentru exportul oricărei liste de obiecte în format CSV.
    /// Suportă atât liste generice (IEnumerable&lt;T&gt;) cât și colecții non-generice (IEnumerable).
    /// </summary>
    public static class CsvHelper
    {
        // Separator folosit între coloane (standard CSV în Europa: semicolon)
        private const string Delimiter = ";";

        /// <summary>
        /// Încapsulează un string între ghilimele și înlocuiește ghilimelele duble interne.
        /// Exemplu: Textul 'Abc"Def' devine '"Abc""Def"'.
        /// </summary>
        private static string Quote(string s)
        {
            if (s == null) return "\"\"";
            var escaped = s.Replace("\"", "\"\"");
            return $"\"{escaped}\"";
        }

        /// <summary>
        /// Exportă o listă generică (cu tipuri cunoscute) într-un fișier CSV.
        /// Fiecare proprietate publică este o coloană, iar fiecare obiect o linie.
        /// </summary>
        /// <typeparam name="T">Tipul elementelor din listă</typeparam>
        /// <param name="items">Colecția de obiecte</param>
        /// <param name="filePath">Calea completă spre fișierul CSV</param>
        public static void ExportToCsv<T>(IEnumerable<T> items, string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath)) return;

            var list = items.ToList();
            if (!list.Any()) return;

            var type = typeof(T);
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            using (var sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                // Scrie antetul cu numele proprietăților
                sw.WriteLine(string.Join(Delimiter, props.Select(p => Quote(p.Name))));

                // Scrie fiecare rând (obiect)
                foreach (var it in list)
                {
                    var fields = new List<string>(props.Length);
                    foreach (var p in props)
                    {
                        var val = p.GetValue(it, null);
                        if (val == null)
                            fields.Add(Quote(string.Empty));
                        else if (val is DateTime dt)
                            fields.Add(Quote(dt.ToString("dd.MM.yyyy")));
                        else
                            fields.Add(Quote(val.ToString()));
                    }
                    sw.WriteLine(string.Join(Delimiter, fields));
                }
            }
        }

        /// <summary>
        /// Exportă orice colecție IEnumerable (non-generică) într-un fișier CSV.
        /// Tipul este dedus din primul element al listei.
        /// </summary>
        /// <param name="items">Colecția de obiecte</param>
        /// <param name="filePath">Calea completă spre fișierul CSV</param>
        public static void ExportToCsv(IEnumerable items, string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath)) return;

            var list = items.Cast<object>().ToList();
            if (!list.Any()) return;

            var type = list.First().GetType();
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            using (var sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                // Antet
                sw.WriteLine(string.Join(Delimiter, props.Select(p => Quote(p.Name))));

                // Date
                foreach (var it in list)
                {
                    var fields = new List<string>(props.Length);
                    foreach (var p in props)
                    {
                        var val = p.GetValue(it, null);
                        if (val == null)
                            fields.Add(Quote(string.Empty));
                        else if (val is DateTime dt)
                            fields.Add(Quote(dt.ToString("dd.MM.yyyy")));
                        else
                            fields.Add(Quote(val.ToString()));
                    }
                    sw.WriteLine(string.Join(Delimiter, fields));
                }
            }
        }
    }
}
