using System;
using System.Collections.Generic;

namespace IteratorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
           
        }

        private static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters)
        {

        }


    }


    public interface IPainter
    {
        bool IsAvailable{get; }

        TimeSpan EstimateTimeToPaint(double sqMeters);
        double EstimateCompensation(double sqMeters);
    }
}
