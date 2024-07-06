using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TECS
{
    namespace Pooling
    {
        public class GameObjectPool : ObjectPool<UnityEngine.GameObject>
        {
            public UnityEngine.GameObject PoolGo { get; protected set; }
            protected Func<UnityEngine.GameObject> create;

            public GameObjectPool()
            {
                PoolGo = new UnityEngine.GameObject("GameObjectPool");
            }

            public GameObjectPool(string parentName)
            {
                PoolGo = new UnityEngine.GameObject(parentName);
            }

            public void SetCreateFunc(Func<UnityEngine.GameObject> func)
            {
                create = func;
            }

            protected override UnityEngine.GameObject Create()
            {
                return create?.Invoke();
            }

            protected override void OnAdd(UnityEngine.GameObject target)
            {
                if (!target) return;

                base.OnAdd(target);
                target.transform.SetParent(PoolGo.transform);
                target.SetActive(false);
            }

            protected override void OnPop(UnityEngine.GameObject target)
            {
                if (!target) return;

                base.OnPop(target);
                target.transform.SetParent(null);
                target.SetActive(true);
            }

            protected override void OnRemove(UnityEngine.GameObject target)
            {
                base.OnRemove(target);
                UnityEngine.Object.Destroy(target);
            }
        }
    }
}
