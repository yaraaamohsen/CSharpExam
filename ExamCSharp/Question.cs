using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamCSharp
{
    public class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public double Mark { get; set; }
        public int RightAnswer { get; set; }
        public Answer[] AnswerList { get; set; } 

        public Question(string header, string body, double mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = new Answer[3];
        }
       
        public Question(int rightAnswer)
        {
            RightAnswer = rightAnswer;
        }

        public Question(string body, double mark)
        {
            Body = body;
            Mark = mark;
            AnswerList = new Answer[3];

        }
    }
}
