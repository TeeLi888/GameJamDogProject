using System;

namespace TECS
{
    namespace Timing
    {
        public class SystemTimer : Timer
        {
            public DateTime StartTime { get; private set; }
            public TimeSpan TimeToRing { get; private set; }
            public TimeSpan TimeElapsed => DateTime.Now - StartTime;

            public SystemTimer()
            {
                StartTime = DateTime.Now;
                TimeToRing = TimeSpan.Zero;
            }

            public SystemTimer(TimeSpan time)
            {
                StartTime = DateTime.Now;
                TimeToRing = time;
            }

            public override bool Ring()
            {
                return TimeElapsed > TimeToRing;
            }

            public override void Reset()
            {
                StartTime = DateTime.Now;
            }

            public void ResetStartTime(DateTime time)
            {
                StartTime = time;
            }

            public void ResetTimeToRing(TimeSpan span)
            {
                TimeToRing = span;
            }
        }
    }
}
