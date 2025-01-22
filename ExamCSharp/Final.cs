using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ExamCSharp
{
    internal class Final : Exam
    {
        public Final(int time, int noOfQuestions) : base(time, noOfQuestions)
        {
        }

        public override void ShowExam()
        {
            double TotalMarks = 0;
            double GainedMarks = 0;

            foreach (var question in Questions)
            {
                Console.WriteLine($"\n{question.Body}");
                for (int i = 0; i < question.AnswerList.Length; i++)
                {
                    Console.WriteLine(question.AnswerList[i]);
                }
                int UserAnswer;
                //Console.WriteLine(question.Header);
                if (question.Header == "TOrF")
                {
                    do
                    {
                        Console.WriteLine("Enter The Right Answer (1 for True, 2 for False): ");
                    }
                    while (!(int.TryParse(Console.ReadLine(), out UserAnswer) && (UserAnswer == 1 || UserAnswer == 2)));
                }
                else
                {
                    do
                    {
                        Console.WriteLine("Enter The Right Answer (1, 2, 3): ");
                    }
                    while (!(int.TryParse(Console.ReadLine(), out UserAnswer) && (UserAnswer == 1 || UserAnswer == 2 || UserAnswer == 3  )));
                }

                if (UserAnswer == question.RightAnswer)
                {
                    Console.WriteLine("Correct *_*");
                    GainedMarks += question.Mark;
                }
                else
                {
                    Console.WriteLine($"Incorrect :(");
                }
                TotalMarks += question.Mark;
            }
            foreach (var question in Questions)
            {
                Console.WriteLine($"\n{question.Body} ==> {question.RightAnswer}");
            }
            Console.WriteLine($"Grade Is: {GainedMarks} / {TotalMarks}");
        }
    }
}
