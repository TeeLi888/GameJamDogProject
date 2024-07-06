using System;

namespace TECS
{
    namespace FSM
    {
        public class QuickState : State
        {
            private readonly Action enter;
            private readonly Action update;
            private readonly Action exit;

            public QuickState(Action onEnter, Action onUpdate, Action onExit)
            {
                enter = onEnter;
                update = onUpdate;
                exit = onExit;
            }

            public QuickState(Action onEnter, Action onExit) : this(onEnter, null, onExit) { }

            public override void OnEnter()
            {
                base.OnEnter();
                enter?.Invoke();
            }

            public override void OnUpdate()
            {
                base.OnUpdate();
                update?.Invoke();
            }

            public override void OnExit()
            {
                base.OnExit();
                exit?.Invoke();
            }
        }
    }
}