using System;
using System.Collections.Generic;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted) {
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

        public override void CalculateStatistics() {
            if (Students.Count < 5) {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            } else {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name) {
            if (Students.Count < 5) {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            } else {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
