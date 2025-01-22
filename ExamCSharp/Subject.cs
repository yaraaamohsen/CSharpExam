using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamCSharp;

namespace ExamCSharp
{
    internal class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam exam { get; set; }

        int ExamType;
        bool isValid = false;

        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        public void CreateExam()
        {
            do
            {
                Console.Write("Please Enter The Type of Exam You Want To Create (1 for Practical, 2 for Final): ");
                bool result = int.TryParse(Console.ReadLine(), out ExamType);

                if (result && (ExamType == 1 || ExamType == 2))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter 1 for Practical or 2 for Final.");
                }
            } while (!isValid);

            int TimeInMinutes;
            do
            {
                Console.Write("Please Enter The Time Of Exam In Minutes: ");
            } while (!int.TryParse(Console.ReadLine(), out TimeInMinutes));

            int NoOfQuestions;
            do
            {
                Console.Write("Please Enter The Number Of Questions You Wanted To Create: ");
            } while (!int.TryParse(Console.ReadLine(), out NoOfQuestions));

            if (ExamType == 1)
            {
                exam = new Practical(TimeInMinutes, NoOfQuestions);
            }
            else
            {
                exam = new Final(TimeInMinutes, NoOfQuestions);
            }

            if (NoOfQuestions > 0)
            {
                for (int i = 1; i <= NoOfQuestions; i++) 
                {
                    Console.WriteLine($"Question {i}:"); 
                    if (ExamType == 1) 
                    {
                        CreateMCQQuestions(exam); 
                    } 
                    else 
                    {
                        string header;
                        do
                        {
                            Console.WriteLine("Please Choose The Type Of Question (1 For True Or False || 2 For MCQ): ");
                            header = Console.ReadLine();

                        } while (header != "1" && header != "2");

                        if (header == "1") 
                        {
                            CreateTFQuestions(exam); 
                        } 
                        else if (header == "2") 
                        {
                            CreateMCQQuestions(exam); 
                        } 
                    } 
                }
            }
        }

        private void CreateTFQuestions(Exam exam)
        {
            string body;
            do
            {
                Console.WriteLine("Enter the Body Of The Question: ");
                body = Console.ReadLine();
            }
            while (int.TryParse(body, out int ex));

            double mark;
            do
            {
                Console.WriteLine("Enter The Marks Of The Question: ");
            }
            while (!double.TryParse(Console.ReadLine(), out mark));

            Question question = new TOrF("TOrF", body, mark);

            int ChosenAnswer;
            do
            {
                Console.WriteLine("Enter The Right Answer (1 for True, 2 for False): ");
            }
            while (!(int.TryParse(Console.ReadLine(), out ChosenAnswer) && (ChosenAnswer == 1 || ChosenAnswer == 2) ));
            question.RightAnswer = ChosenAnswer;
            exam.AddQuestion(question);
        }

        private void CreateMCQQuestions(Exam exam) 
        {
            string body;
            do
            {
                Console.WriteLine("Enter the Body Of The Question: ");
                body = Console.ReadLine();
            }
            while (int.TryParse(body, out int ex));
            
            double mark;
            do
            {
                Console.WriteLine("Enter The Marks Of The Question: ");
            }
            while (!double.TryParse(Console.ReadLine(), out mark));

            Question question = new MCQ(body, mark); 
            
            Console.WriteLine("Enter The Choices For The Question: ");
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"Enter Choice {j + 1}: ");
                //question.AnswerList[1] = new Answer(1, "Hello From Debugging");
                //Console.WriteLine(question.AnswerList[1].Text);
                question.AnswerList[j] = new Answer(j + 1, Console.ReadLine());
                //Console.WriteLine(question.AnswerList[j].Text);
            }

            int ChosenAnswer;
            do
            {
                Console.WriteLine("Specify The Right Choice (1, 2, 3):  ");
            }
            while (!(int.TryParse(Console.ReadLine(), out ChosenAnswer) && (ChosenAnswer == 1 || ChosenAnswer == 2 || ChosenAnswer == 3)));
            
            question.RightAnswer = ChosenAnswer;
            //Console.WriteLine(question.RightAnswer);
            exam.AddQuestion(question); 
        }
    }
}