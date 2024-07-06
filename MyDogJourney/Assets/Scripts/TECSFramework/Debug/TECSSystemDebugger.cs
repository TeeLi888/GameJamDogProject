using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TECS
{
    namespace Debugging
    {
        public class TECSSystemDebugger : MonoBehaviour
        {
            [SerializeReference]
            public TECSSystem system;

            private static GameObject parent;
            public static GameObject Parent
            {
                get
                {
                    if (!parent)
                    {
                        parent = new GameObject("Systems");
                    }
                    return parent;
                }
            }

            public static TECSSystemDebugger Create<T>(T system) where T : TECSSystem
            {
                GameObject go = new GameObject(system.GetType().Name);
                TECSSystemDebugger debugger = go.AddComponent<TECSSystemDebugger>();
                debugger.system = system;
                debugger.transform.SetParent(Parent.transform);
                return debugger;
            }
        }
    }
}
