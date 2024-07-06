namespace TECS
{
    namespace LazyInit
    {
        public class LazyInitField<T> : LazyInitGetter<T> where T : class, new()
        {
            public override T Get()
            {
                if (_value == null) _value = new T();
                return _value;
            }
        }
    }
}
