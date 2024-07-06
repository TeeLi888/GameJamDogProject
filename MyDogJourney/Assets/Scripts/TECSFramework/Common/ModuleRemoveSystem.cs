using System.Collections;
using System.Collections.Generic;
using TECS;

public class ModuleRemoveSystem : TECSSystem<ModuleRemoveSystem>
{
    private readonly List<TECSModule> toRemove;

    public ModuleRemoveSystem()
    {
        toRemove = new List<TECSModule>();
    }

    public override void LateUpdate()
    {
        base.LateUpdate();
        Clear();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        Clear();
    }

    public void AddToRemove(TECSModule module)
    {
        if (module == null) return;

        if (!toRemove.Contains(module))
        {
            toRemove.Add(module);
        }
    }

    private void Clear()
    {
        for (int i = 0; i < toRemove.Count; ++i)
        {
            TECSEntity.RemoveModuleImmediate(toRemove[i]);
        }
        toRemove.Clear();
    }
}
