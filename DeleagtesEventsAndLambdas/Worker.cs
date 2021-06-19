using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeleagtesEventsAndLambdas
{
    public delegate void WorkPerfomedHandler(object sender, WorkPerformedEventArgs args);

    public class Worker
    {
        //Below approach is used to create events using in-build delegate - EventHandler and
        //for this no explicit delegate declaration is not required. 
        //public event EventHandler<WorkPerformedEventArgs> WorkPerformed1;
        public event WorkPerfomedHandler WorkPerfomed;
        public event EventHandler WorkCompleted;

        public void DoWork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; i++)
            {
                Thread.Sleep(1000);
                OnWorkPerformed(i+1, workType);
            }
            OnWorkCompleted();  
        }

        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            //First approach to rasie event by directly calling the declared event
            //if (WorkPerfomed != null)
            //{
            //    WorkPerfomed(hours, workType);
            //}

            //Second approach to rasie event by using the delegate
            var del = WorkPerfomed as WorkPerfomedHandler;
            if (del != null)
            {
                del(this, new WorkPerformedEventArgs(hours, workType));
            }

        }

        protected virtual void OnWorkCompleted()
        {
            //First approach to rasie event by directly calling the declared event
            //if (WorkCompleted != null)
            //{
            //    WorkCompleted(this, EventArgs.Empty);
            //}

            //Second approach to rasie event by using the delegate
            var del = WorkCompleted;
            if (del != null)
            {
                del(this, EventArgs.Empty);
            }
        }
    }

    public enum WorkType
    {
         Design,
         Develop, 
         Test,
         Deploy
    }
}
