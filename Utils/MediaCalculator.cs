using System;
using System.Collections.Generic;
using System.Linq;
using StudentGradeApp.Models;

namespace StudentGradeApp.Utils
{
    public static class MediaCalculator
    {
        public static double CalculMedia(IEnumerable<Nota> note)
        {
            var values = note.Select(n => n.Valoare);
            return values.Any() ? Math.Round(values.Average(), 2) : 0;
        }

        public static bool EstePromovat(IEnumerable<Nota> note, double prag = 5.0)
        {
            return CalculMedia(note) >= prag;
        }
    }
}