using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{

    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
           Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            int numberOfStudents = Students.Count;
            int twentyPercent = numberOfStudents * (int)0.2;
            int betterStudents = 0;

            if (numberOfStudents < 5)
                throw new InvalidOperationException();
            foreach (var student in Students)
            {
                if (student.AverageGrade > averageGrade)
                {
                    betterStudents++;
                }
            }

            /*            if (betterStudents < twentyPercent)
                            return 'A';
                        else if (betterStudents >= twentyPercent && betterStudents < 2 * twentyPercent)
                            return 'B';
                        else if (betterStudents >= 2 * twentyPercent && betterStudents < 4 * twentyPercent)
                            return 'C';
                        else if (betterStudents >= 4 * twentyPercent && betterStudents < 6 * twentyPercent)
                            return 'D';
                        else return 'F';*/


/*            int numberOfStudents = Students.Count;

            //double allStudentsGrades = Students.Average(s => s.AverageGrade);

            int twentyPercent = (int)Math.Ceiling(numberOfStudents * 0.2);
            int numberOfHigherGrades = 0;
            int currentGradeIndex = 0;

            foreach (var student in Students)
            {
                student.LetterGrade = GetLetterGrade(student.AverageGrade);

                if (student.LetterGrade > averageGrade)
                {
                    numberOfHigherGrades++;
                }
                currentGradeIndex++;

                //checking if 20% milestone is reached and drop the grade if so
                if (currentGradeIndex % twentyPercent == 0)
                {
                    if (numberOfHigherGrades >= twentyPercent)
                        averageGrade -= 10;

                    numberOfHigherGrades = 0; //reset counter
                }
            }*/

            if (numberOfStudents < 5)
                throw new InvalidOperationException("Invalid operation");

            else if (averageGrade >= 80)
                return 'A';
            else if (averageGrade >= 60)
                return 'B';
            else if (averageGrade >= 40)
                return 'C';
            else if (averageGrade >= 20)
                return 'D';

            else return 'F';

        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }                
            else
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            else
            base.CalculateStudentStatistics(name);
        }
    }
}
