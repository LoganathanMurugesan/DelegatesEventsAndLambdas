using System;

namespace DeleagtesEventsAndLambdas
{
    class Program
    {
        static void Main(string[] args)
        {
            var worker = new Worker();
            worker.WorkPerfomed += new WorkPerfomedHandler(Work_WorkPerformed);
            worker.WorkCompleted += new EventHandler(Work_WorkCompleted);
            worker.DoWork(8, WorkType.Develop);
        }

        private static void Work_WorkCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Work is done");
        }

        private static void Work_WorkPerformed(object sender, WorkPerformedEventArgs args)
        {
            Console.WriteLine("Hours worked: " + args.Hours + " " + args.WorkType);
        }
        
    }
}
