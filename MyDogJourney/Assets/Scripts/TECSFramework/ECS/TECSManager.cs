
namespace TECS
{
    public class TECSManager
    {
        public virtual void Init() { }
        public virtual void Release() { }
    }

    public class TECSManager<T> : TECSManager where T : TECSManager, new()
    {
        private static T inst;
        public static T Inst { 
            get
            {
                if (inst == null) 
                { 
                    inst = new T(); 
                    inst.Init();
                }
                return inst;
            }
        }
        public static bool IsInit => inst != null;

        public override void Release()
        {
            base.Release();
            OnRelease();
            inst = null;
        }

        protected virtual void OnRelease() { }
    }
}
