using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TECS
{
    public class TECSEntity : MonoBehaviour
    {
        [SerializeReference]
        private List<TECSData> datas = new List<TECSData>();

        [SerializeReference]
        private List<TECSModule> modules = new List<TECSModule>();

        #region LifeCycle

        protected virtual void Awake()
        {
            InitData();
            InitModules();
        }

        protected virtual void InitData() { }

        protected virtual void InitModules() { }

        #endregion

        #region Data and Module

        public T AddData<T>() where T : TECSData, new()
        {
            T data = new T();
            TECSComponentScheme.AddComponent(datas, data);
            return data;
        }

        public T AddData<T>(T data) where T : TECSData
        {
            TECSComponentScheme.AddComponent(datas, data);
            return data;
        }

        public T GetData<T>()
        {
            return TECSComponentScheme.GetComponent<T, TECSData>(datas);
        }

        public List<T> GetAllData<T>()
        {
            return TECSComponentScheme.GetComponents<T, TECSData>(datas);
        }

        public void RemoveData(TECSData data)
        {
            if (data == null) return;
            TECSComponentScheme.RemoveComponent(datas, data);
        }

        public T AddModule<T>() where T : TECSModule, new()
        {
            T module = new T()
            {
                Entity = this
            };
            TECSComponentScheme.AddComponent(modules, module);
            module.OnCreate();
            return module;
        }

        public T GetModule<T>()
        {
            return TECSComponentScheme.GetComponent<T, TECSModule>(modules);
        }

        public List<T> GetAllModules<T>()
        {
            return TECSComponentScheme.GetComponents<T, TECSModule>(modules);
        }

        public static void RemoveModuleImmediate(TECSModule module)
        {
            if(module == null) return;
            if (module.Entity)
            {
                module.Entity.RemoveModuleInternal(module);
            }
            module.Entity = null;
        }

        public static void RemoveModule(TECSModule module)
        {
            if (module == null) return;
            if (ModuleRemoveSystem.IsInit)
            {
                ModuleRemoveSystem.Inst.AddToRemove(module);
            }
            else
            {
                Debug.LogWarning("Late removal Failed because ModuleRemoveSystem is not initialized. Using immediate removal instead");
                RemoveModuleImmediate(module);
            }
        }

        private void RemoveModuleInternal(TECSModule module)
        {
            TECSComponentScheme.RemoveComponent(modules, module);
            module.OnRemove();
        }

        private void RemoveAllModules()
        {
            List<TECSModule> copiedModules = new List<TECSModule>(modules);
            for (int i = 0; i < copiedModules.Count; ++i)
            {
                RemoveModuleImmediate(copiedModules[i]);
            }
        }

        protected virtual void OnDestroy()
        {
            RemoveAllModules();
        }

        #endregion
    }
}
