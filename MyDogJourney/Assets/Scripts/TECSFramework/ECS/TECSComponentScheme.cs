using System.Collections;
using System.Collections.Generic;

namespace TECS
{
    public static class TECSComponentScheme
    {
        public static T AddComponent<T, K>(List<K> comps, T newComp) where T : K
        {
            comps.Add(newComp);
            return newComp;
        }

        public static T GetComponent<T, K>(List<K> comps)
        {
            for (int i = 0; i < comps.Count; ++i)
            {
                K comp = comps[i];
                if (comp is T t)
                {
                    return t;
                }
            }
            return default;
        }

        public static List<T> GetComponents<T, K>(List<K> comps)
        {
            List<T> results = new List<T>();
            for (int i = 0; i < comps.Count; ++i)
            {
                K comp = comps[i];
                if (comp is T t)
                {
                    results.Add(t);
                }
            }
            return results;
        }

        public static void RemoveComponent<T, K>(List<K> comps, T comp) where T : K
        {
            comps.Remove(comp);
        }
    }
}
