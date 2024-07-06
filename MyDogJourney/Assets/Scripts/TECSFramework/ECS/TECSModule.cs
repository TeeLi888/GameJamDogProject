namespace TECS
{
    [System.Serializable]
    public class TECSModule
    {
        public TECSEntity Entity { get; internal set; }

        public virtual void OnCreate() { }

        public virtual void OnRemove() { }
    }
}
