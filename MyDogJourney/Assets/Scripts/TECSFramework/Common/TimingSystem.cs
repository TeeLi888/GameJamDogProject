using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TECS;
using TECS.Timing;

public class TimingSystem : TECSMonoSystem<TimingSystem>
{
    private List<TimingProcess> processes;
    private List<TimingProcess> toDispose;

    public override void Init()
    {
        base.Init();
        processes = new List<TimingProcess>();
        toDispose = new List<TimingProcess>();
    }

    public override void Update()
    {
        base.Update();
        for(int i = 0; i < processes.Count; ++i)
        {
            TimingProcess process = processes[i];
            if (!process.UseFixedUpdate)
            {
                UpdateTimer(process, Time.deltaTime);
            }
        }
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        for (int i = 0; i < processes.Count; ++i)
        {
            TimingProcess process = processes[i];
            if (process.UseFixedUpdate)
            {
                UpdateTimer(process, Time.fixedDeltaTime);
            }
        }
    }

    public override void LateUpdate()
    {
        base.LateUpdate();
        for (int i = 0; i < toDispose.Count; ++i)
        {
            TimingProcess process = toDispose[i];
            processes.Remove(process);
        }
        toDispose.Clear();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        for (int i = 0; i < processes.Count; ++i)
        {
            processes[i].Dispose();
        }
        processes.Clear();
        toDispose.Clear();
    }

    public TimingProcess Run(string name, float time, Action onRing, bool useFixedUpdate = false)
    {
        if(time < 0f)
        {
            Debug.LogWarning("Start Timer Fail. Time must be positive.");
            return null;
        }
        TimingProcess process = new TimingProcess(time)
        {
            Name = name,
            RingAction = onRing,
            UseFixedUpdate = useFixedUpdate
        };
        processes.Add(process);
        return process;
    }

    public TimingProcess RunOnce(string name, float time, Action onRing, bool useFixedUpdate = false)
    {
        if (time < 0f)
        {
            Debug.LogWarning("Start Timer Fail. Time must be positive.");
            return null;
        }
        TimingProcess process = new TimingProcess(time)
        {
            Name = name,
            RingAction = onRing,
            UseFixedUpdate = useFixedUpdate,
            IsOnce = true
        };
        processes.Add(process);
        return process;
    }

    public void Freeze(TimingProcess process, bool isFreeze)
    {
        process?.Freeze(isFreeze);
    }

    public void Stop(TimingProcess process)
    {
        if (process == null) return;
        process.Dispose();
        toDispose.Add(process);
    }

    public TimingProcess FindProcessByName(string name)
    {
        return processes.Find((p) => p.Name == name);
    }

    private void UpdateTimer(TimingProcess process, float deltaTime)
    {
        if (process.IsDisposed || process.IsFrozen) return;

        process.Timer.Elapse(deltaTime);
        if (process.Timer.Ring())
        {
            process.SafeInvoke();

            if (process.IsOnce)
            {
                Stop(process);
            }
            else
            {
                process.Timer.Reset();
            }
        }
    }
}