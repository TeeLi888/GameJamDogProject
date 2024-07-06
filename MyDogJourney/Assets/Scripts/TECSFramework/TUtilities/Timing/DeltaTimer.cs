using UnityEngine;

namespace TECS
{
    namespace Timing
    {
        public class DeltaTimer : Timer
        {
            public float TimeElapsed { get; private set; }
            public float TimeToRing { get; private set; }

            private int digit; //digit kept for float accuracy. -1 for do not use
            public DeltaTimer()
            {
                TimeElapsed = 0;
                TimeToRing = 0;
                digit = -1;
            }

            public DeltaTimer(float time)
            {
                TimeElapsed = 0;
                TimeToRing = time;
                digit = -1;
            }

            public void Elapse(float time)
            {
                TimeElapsed += time;
            }

            public override bool Ring()
            {
                return KeepDigit(TimeElapsed, digit) >= KeepDigit(TimeToRing, digit);
            }

            public override void Reset()
            {
                TimeElapsed = 0;
            }

            public void ResetTimeToRing(float timeToRing)
            {
                TimeToRing = timeToRing;
            }

            public void SetFloatAccuracy(int d)
            {
                digit = d;
            }

            private float KeepDigit(float value, int d)
            {
                if (d < 0)
                {
                    return value;
                }
                int mult = Mathf.RoundToInt(Mathf.Pow(10, d));
                return Mathf.Round(value * mult) / mult;
            }
        }
    }
}
