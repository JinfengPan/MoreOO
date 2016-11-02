using System;

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
}