using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamCSharp
{
    public abstract class Exam
    {
        public int Time { get; set; }
        public int NoOfQuestions { get; set; }
        public Question[] Questions { get; set; }
        private int currentQuestionIndex = 0;

        public Exam(int time, int noOfQuestions)
        {
            Time = time;
            NoOfQuestions = noOfQuestions;
            Questions = new Question[NoOfQuestions];
        }

        public Exam() { }
        public abstract void ShowExam();

        public void AddQuestion(Question question)
        {
            if (currentQuestionIndex < NoOfQuestions)
            {
                Questions[currentQuestionIndex] = question;
                currentQuestionIndex++;
            }
        }
    }
}
