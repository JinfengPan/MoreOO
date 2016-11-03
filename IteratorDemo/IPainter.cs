using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorDemo
{
    public interface IPainter
    {
        bool IsAvailable{get; }

        TimeSpan EstimateTimeToPaint(double sqMeters);
        double EstimateCompensation(double sqMeters);
    }

    class ProportionalPainter: IPainter
    {
        public TimeSpan TimePerSqMeter { get; set; }

        public double DollarsPerHour { get; set; }

        public bool IsAvailable => true;

        public TimeSpan EstimateTimeToPaint(double sqMeters) =>
            TimeSpan.FromHours(this.TimePerSqMeter.TotalHours * sqMeters);

        public double EstimateCompensation(double sqMeters) =>
            EstimateTimeToPaint(sqMeters).TotalHours*this.DollarsPerHour;
    }

    class Painters
    {
        private IEnumerable<IPainter> ContainedPainters { get; }

        public Painters(IEnumerable<IPainter> painters)
        {
            this.ContainedPainters = painters.ToList();
        }


        public Painters GetAvailable()
        {
            if (this.ContainedPainters.All(painter => painter.IsAvailable))
                return this;

            return new Painters(this.ContainedPainters.Where(painter => painter.IsAvailable));
        }

        public IPainter GetCheapstOne(double sqMeters) =>
            this.ContainedPainters.WithMinimum(painter => painter.EstimateCompensation(sqMeters));


        public IPainter GetFastestOne(double sqMeters) =>
            this.ContainedPainters.WithMinimum(painter => painter.EstimateTimeToPaint(sqMeters));
    }
}