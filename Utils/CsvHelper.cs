using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace StudentGradeApp.Utils
{
    public static class CsvHelper
    {
        // Generic version stays for strongly‐typed calls  
        public static void ExportToCsv<T>(IEnumerable<T> items, string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) return;
            using (var sw = new StreamWriter(filePath))
            {
                var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                sw.WriteLine(string.Join(",", props.Select(p => p.Name))); // Fixed: Changed ',' to ","
                foreach (var it in items)
                {
                    var vals = props.Select(p => p.GetValue(it)?.ToString().Replace(',', ';') ?? string.Empty);
                    sw.WriteLine(string.Join(",", vals)); // Fixed: Changed ',' to ","
                }
            }
        }

        // Non‐generic overload that works with plain IEnumerable  
        public static void ExportToCsv(IEnumerable items, string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) return;
            var list = items.Cast<object>().ToList();
            if (!list.Any()) return;
            using (var sw = new StreamWriter(filePath))
            {
                var type = list.First().GetType();
                var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                sw.WriteLine(string.Join(",", props.Select(p => p.Name))); // Fixed: Changed ',' to ","
                foreach (var it in list)
                {
                    var vals = props.Select(p => p.GetValue(it)?.ToString().Replace(',', ';') ?? string.Empty);
                    sw.WriteLine(string.Join(",", vals)); // Fixed: Changed ',' to ","
                }
            }
        }
    }
}
