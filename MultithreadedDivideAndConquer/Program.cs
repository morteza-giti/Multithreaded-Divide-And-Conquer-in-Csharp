using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace MultithreadedDivideAndConquer
{
    class Program
    {
        static void Main(string[] args)
        {
            var unsorted = new Queue<Queue<int>>();
            long listLength = 10;
			int maxSize = 1000;            
            Random rand = new Random();
            Console.WriteLine("Creating list of size " + listLength );
            for (int i = 0; i < listLength; ++i)
            {
                var l = new Queue<int>();
                l.Enqueue(rand.Next ( maxSize ));
                unsorted.Enqueue(l);
            }
			Stopwatch parallelSW = new Stopwatch ();
			Console.WriteLine ( "Starting Parallel MergeSort" );
			var pending = new Queue<Queue<int>> ();
			foreach ( Queue<int> q in unsorted )
			{
				pending.Enqueue ( new Queue<int> ( q ) );
			}
			parallelSW.Start ();
			Queue<int> sortedParallel = Sorter.ParallelMergeSort ( pending );
			parallelSW.Stop ();
			Console.WriteLine ( "ParallelMergeSort - Time Elapsed: " + ( parallelSW.ElapsedMilliseconds ) + "ms" );
			foreach ( int item in sortedParallel )
			{
				Console.WriteLine ( item );
			}    
            Console.Write("Press any key to exit...");
            Console.Read();
        }
    }
}
