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

        private static IPainter FindFastedPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            return painters
                .Where(painter => painter.IsAvailable)
                .WithMinimum(painter => painter.EstimateTimeToPaint(sqMeters));
        }


    }
}
