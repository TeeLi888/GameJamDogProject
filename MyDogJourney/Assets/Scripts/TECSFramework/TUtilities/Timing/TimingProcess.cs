using System;
using UnityEngine;

namespace TECS
{
    namespace Timing
    {
        public class TimingProcess
        {
            public string Name { get; set; }
            public DeltaTimer Timer { get; private set; }
            public Action RingAction { get; set; }
            public bool IsOnce { get; set; }
            public bool UseFixedUpdate { get; set; }

            public bool IsFrozen { get; private set; }
            public bool IsDisposed { get; private set; }

            public TimingProcess(float time)
            {
                Timer = new DeltaTimer(time);
                IsOnce = false;
                UseFixedUpdate = false;
                IsFrozen = false;
                IsDisposed = false;
            }

            public void Freeze(bool isFreeze)
            {
                IsFrozen = isFreeze;
            }

            public void Dispose()
            {
                IsDisposed = true;
            }

            public void SafeInvoke()
            {
                try
                {
                    RingAction?.Invoke();
                }
                catch (Exception e)
                {
                    Debug.LogError($"Exception in timing process {Name} with \n " +
                        $"Message: {e.Message}\n " +
                        $"Stack trace: {e.StackTrace}");
                }
            }
        }
    }
}