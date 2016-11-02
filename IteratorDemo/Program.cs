using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
           
        }

        private static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            return
                painters
                    .Where(painter => painter.IsAvailable)
                    .WithMinimum(painter => painter.EstimateCompensation(sqMeters));
        }


    }


    public interface IPainter
    {
        bool IsAvailable{get; }

        TimeSpan EstimateTimeToPaint(double sqMeters);
        double EstimateCompensation(double sqMeters);
    }
}
