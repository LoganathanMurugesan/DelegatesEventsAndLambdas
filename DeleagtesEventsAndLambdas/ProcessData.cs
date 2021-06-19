using System;

namespace DeleagtesEventsAndLambdas
{
    //For demonstrating .Net in-built delegates Action<T> and Func<T,TResult>
    public class ProcessData
    {
        public void ProcessAction(int x, int y, Action<int, int> action)
        {
            action(x, y);
            Console.WriteLine("Action has been processed");
        }

        public int ProcessFunc(int x, int y, Func<int, int, int> func)
        {
            int sum = func(x,y);
            return sum;
        }
    }

    public class ProcessDataConsumer
    {
        Action<int, int> myAddAction = (x, y) => Console.WriteLine(x + y);
        Action<int, int> myMulAction = (x, y) => Console.WriteLine(x * y);

        Func<int, int, int> myAddFunc = (x, y) => x + y;
        Func<int, int, int> myMulFunc = (x, y) => x * y;

        public void Consumer()
        {
            var processData = new ProcessData();

            //Action<T> 
            processData.ProcessAction(2,3,myAddAction);
            processData.ProcessAction(6,3,myMulAction);

            //Func<T, TResult>
            int AddResult = processData.ProcessFunc(4, 5, myAddFunc);
            int MulResutl = processData.ProcessFunc(2,6, myMulFunc);
        }

    }
}
