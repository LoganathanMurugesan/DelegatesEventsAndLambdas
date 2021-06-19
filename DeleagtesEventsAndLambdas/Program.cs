using System;

namespace DeleagtesEventsAndLambdas
{
    class Program
    {
        static void Main(string[] args)
        {
            var worker = new Worker();

            //Below is example of the delegate inference, newing up the delegate is not required
            //because the delegate is already defined on the event.
            //worker.WorkPerfomed += Work_WorkPerformed;
            //worker.WorkCompleted += Work_WorkCompleted;

            //This will detach the event handler from the event and the event handler will 
            //never be notified
            //worker.WorkCompleted -= Work_WorkCompleted;

            //attaching the anonymous method directly to the event handler
            //worker.WorkPerfomed += delegate(object sender, WorkPerformedEventArgs args)
            //{
            //    Console.WriteLine("Work is done");
            //};

            worker.WorkPerfomed += new WorkPerfomedHandler(Work_WorkPerformed);
            worker.WorkCompleted += new EventHandler(Work_WorkCompleted);
            worker.DoWork(8, WorkType.Develop);
        }

      
        private static void Work_WorkPerformed(object sender, WorkPerformedEventArgs args)
        {
            Console.WriteLine("Hours worked: " + args.Hours + " " + args.WorkType);
        }

        private static void Work_WorkCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Work is done");
        }


    }
}
