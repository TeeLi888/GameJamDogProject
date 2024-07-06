using System;

namespace TECS
{
    namespace Timing
    {
        public class SpanDeltaTimer : Timer
        {
            public TimeSpan TimeElapsed { get; private set; }
            public TimeSpan TimeToRing { get; private set; }

            public SpanDeltaTimer()
            {
                TimeElapsed = TimeSpan.Zero;
                TimeToRing = TimeSpan.Zero;
            }

            public SpanDeltaTimer(TimeSpan time)
            {
                TimeElapsed = TimeSpan.Zero;
                TimeToRing = time;
            }

            public void Elapse(TimeSpan time)
            {
                TimeElapsed += time;
            }

            public override bool Ring()
            {
                return TimeElapsed > TimeToRing;
            }

            public override void Reset()
            {
                TimeElapsed = TimeSpan.Zero;
            }

            public void ResetTimeToRing(TimeSpan timeToRing)
            {
                TimeToRing = timeToRing;
            }
        }
    }
}
