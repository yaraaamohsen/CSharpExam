using System.Diagnostics;

namespace ExamCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject sub01 = new Subject(10, "C#");
            sub01.CreateExam();
            Console.Clear();
            Console.WriteLine("Do You Want To Start The Exam (y|n): ");

            if (char.Parse(Console.ReadLine()) == 'y')
            {
                Console.Clear();
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                sub01.exam.ShowExam();
                Console.WriteLine($"\nThe Elapsed Time is : {stopwatch.Elapsed}");
            }
        }
    }
}
