using System;

namespace TECS
{
    namespace LazyInit
    {
        public class LazyInitCustomField<T> : LazyInitGetter<T> where T : class
        {
            private readonly Func<T> initFunc;
            public LazyInitCustomField(Func<T> initializer)
            {
                initFunc = initializer;
            }

            public override T Get()
            {
                if (_value == null && initFunc != null) _value = initFunc.Invoke();
                return _value;
            }
        }
    }
}
