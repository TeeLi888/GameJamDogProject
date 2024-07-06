using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TECS
{
    public static class TECSExtensions
    {
        public static T GetModule<T>(this UnityEngine.GameObject go)
        {
            TECSEntity entity = go.GetComponent<TECSEntity>();
            if (entity)
            {
                return entity.GetModule<T>();
            }
            return default;
        }

        public static List<T> GetAllModules<T>(this UnityEngine.GameObject go)
        {
            TECSEntity entity = go.GetComponent<TECSEntity>();
            if (entity)
            {
                return entity.GetAllModules<T>();
            }
            return new List<T>();
        }

        public static T GetModuleInChildren<T>(this UnityEngine.GameObject go)
        {
            TECSEntity entity = go.GetComponentInChildren<TECSEntity>();
            if (entity)
            {
                return entity.GetModule<T>();
            }
            return default;
        }

        public static T GetModuleInParent<T>(this UnityEngine.GameObject go)
        {
            TECSEntity entity = go.GetComponentInParent<TECSEntity>();
            if (entity)
            {
                return entity.GetModule<T>();
            }
            return default;
        }

        public static List<T> GetAllModulesInChildren<T>(this UnityEngine.GameObject go)
        {
            TECSEntity[] entities = go.GetComponentsInChildren<TECSEntity>();
            List<T> list = new List<T>();
            for(int i = 0; i < entities.Length; ++i)
            {
                list.AddRange(entities[i].GetAllModules<T>());
            }
            return list;
        }

        public static List<T> GetAllModulesInParent<T>(this UnityEngine.GameObject go)
        {
            TECSEntity[] entities = go.GetComponentsInParent<TECSEntity>();
            List<T> list = new List<T>();
            for (int i = 0; i < entities.Length; ++i)
            {
                list.AddRange(entities[i].GetAllModules<T>());
            }
            return list;
        }
    }
}
