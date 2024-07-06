using UnityEngine;

namespace TECS
{
    public class TECSSystem
    {
        public virtual void Start() 
        {
            if (Debugging.TECSDebugGlobal.Debug)
            {
                Debugging.TECSSystemDebugger.Create(this);
            }
        }

        public virtual void Update() { }

        public virtual void FixedUpdate() { }

        public virtual void LateUpdate() { }

        public virtual void OnDestroy() { }
    }

    public class TECSSystem<T> : TECSSystem where T : TECSSystem, new()
    {
        public static T Inst { get; protected set; }
        public static bool IsInit => Inst != null;

        public static void Create()
        {
            if (!IsInit)
            {
                Inst = new T();
            }
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            Inst = null;
        }
    }

    public class TECSMonoSystem : MonoBehaviour
    {
        public virtual void Init() { }
        public virtual void Update() { }

        public virtual void FixedUpdate() { }

        public virtual void LateUpdate() { }

        public virtual void OnDestroy() { }
    }

    public class TECSMonoSystem<T> : TECSMonoSystem where T : TECSMonoSystem
    {
        public static T Inst { get; protected set; }
        public static bool IsInit => Inst != null;
        public bool initOnAwake = false;

        public virtual void Awake()
        {
            if (initOnAwake)
            {
                Init();
            }
        }

        public override void Init()
        {
            base.Init();
            Inst = this as T;
        }

        public static void Create()
        {
            if (!IsInit)
            {
                GameObject go = new GameObject(typeof(T).Name);
                T sys = go.AddComponent<T>();
                sys.Init();
            }
        }

        public static void Create(GameObject go)
        {
            if (!IsInit && go)
            {
                T sys = go.AddComponent<T>();
                sys.Init();
            }
        }
    }
}
