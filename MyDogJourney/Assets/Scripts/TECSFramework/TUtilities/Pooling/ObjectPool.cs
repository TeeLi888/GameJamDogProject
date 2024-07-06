using System.Collections;
using System.Collections.Generic;

namespace TECS
{
    namespace Pooling
    {
        public class ObjectPool<T> : ICollection<T>
        {
            public int Count => pool.Count;

            public bool IsReadOnly => false;

            protected readonly Queue<T> pool;

            public ObjectPool()
            {
                pool = new Queue<T>();
            }

            public virtual T Pop()
            {
                T target = FromPool();
                OnPop(target);
                return target;
            }

            public virtual void Add(T target)
            {
                pool.Enqueue(target);
                OnAdd(target);
            }

            protected virtual T FromPool()
            {
                if (Count <= 0)
                {
                    return Create();
                }
                return pool.Dequeue();
            }

            public virtual void Clear()
            {
                foreach (T target in pool)
                {
                    OnRemove(target);
                }
                pool.Clear();
            }

            protected virtual T Create()
            {
                return default;
            }

            protected virtual void OnPop(T target) { }

            protected virtual void OnAdd(T target) { }

            protected virtual void OnRemove(T target) { }


            public bool Contains(T item)
            {
                return pool.Contains(item);
            }

            public void CopyTo(T[] array, int arrayIndex)
            {
                pool.CopyTo(array, arrayIndex);
            }

            public bool Remove(T item)
            {
                return false;
            }

            public IEnumerator<T> GetEnumerator()
            {
                return pool.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return pool.GetEnumerator();
            }
        }
    }
}
