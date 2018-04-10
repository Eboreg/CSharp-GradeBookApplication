using System;
using System.Collections.Generic;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name) {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade) {
            if (Students.Count < 5)
                throw new InvalidOperationException();
            double studentsPerGrade = Students.Count * 0.2;
            List<double> averageGrades = new List<double>();
            foreach (Student student in Students) {
                averageGrades.Add(student.AverageGrade);
            }
            averageGrades.Sort();
            //for (int i = averageGrades.Count - 1; i >= 0; i--) {
            for (int i = 0; i < averageGrades.Count; i++) {
                if (averageGrades[i] >= averageGrade) {
                    double percentile = (double) i / (averageGrades.Count - 1);
                    if (percentile >= 0.8)
                        return 'A';
                    else if (percentile >= 0.6)
                        return 'B';
                    else if (percentile >= 0.4)
                        return 'C';
                    else if (percentile >= 0.2)
                        return 'D';
                    else
                        return 'F';
                }
            }
            return 'A';
        }
    }
}
