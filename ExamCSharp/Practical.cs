using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamCSharp
{
    internal class Practical : Exam
    {
        public Practical(int time, int noOfQuestions) : base(time, noOfQuestions)
        {
        }

        public override void ShowExam()
        {
            foreach (var question in Questions)
            {
                Console.WriteLine(question.Body);
                for (int i = 0; i < question.AnswerList.Length; i++)
                {
                    Console.WriteLine(question.AnswerList[i]);
                }
                int UserAnswer;
                do
                {
                    Console.WriteLine("Enter The Right Answer (1, 2, 3): ");
                }
                while (!(int.TryParse(Console.ReadLine(), out UserAnswer) && (UserAnswer == 1 || UserAnswer == 2 || UserAnswer == 3)));

                if (UserAnswer == question.RightAnswer)
                {
                    Console.WriteLine("Correct *_*");
                }
                else
                {
                    Console.WriteLine($"InCorrect");
                }                
            }


            Console.WriteLine("\nThe Correct Answers Is: ");
            foreach (var question in Questions)
            {
                Console.Write($"\n{question.Body} ==> {question.RightAnswer}");
            }
        }
    }
}
