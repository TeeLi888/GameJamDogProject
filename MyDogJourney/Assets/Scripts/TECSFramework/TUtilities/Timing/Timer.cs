namespace TECS
{
    namespace Timing
    {
        public abstract class Timer
        {
            public abstract bool Ring();
            public abstract void Reset();
        }
    }
}