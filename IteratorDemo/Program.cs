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

        private static IPainter FindCheapestPainter(double sqMeters, Painters painters) =>
            painters.GetAvailable().GetCheapstOne(sqMeters);

        private static IPainter FindFastedPainter(double sqMeters, Painters painters) =>
            painters.GetAvailable().GetFastestOne(sqMeters);


        private static IPainter WorkTogether(double sqMeters, IEnumerable<IPainter> painters)
        {
            TimeSpan time =
                TimeSpan.FromHours(
                    1/
                    painters
                        .Where(painter => painter.IsAvailable)
                        .Select(painter => 1/painter.EstimateTimeToPaint(sqMeters).TotalHours)
                        .Sum());

            double cost = painters
                .Where(painter => painter.IsAvailable)
                .Select(painter =>
                    painter.EstimateCompensation(sqMeters)/
                    painter.EstimateTimeToPaint(sqMeters).TotalHours*
                    time.TotalHours)
                .Sum();

            return new ProportionalPainter()
            {
                TimePerSqMeter = TimeSpan.FromHours(time.TotalHours/sqMeters),
                DollarsPerHour = cost/time.TotalHours
            };

        }


    }
}
