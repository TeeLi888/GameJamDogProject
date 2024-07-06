namespace TECS
{
    namespace LazyInit
    {
        public abstract class LazyInitGetter<T> where T : class
        {
            protected T _value;
            public abstract T Get();

            public bool Initialized => _value != null;

            public void Clear()
            {
                _value = null;
            }
        }
    }
}
