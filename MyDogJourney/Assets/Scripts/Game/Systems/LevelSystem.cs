using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TECS;

public class LevelSystem : TECSSystem<LevelSystem>
{
    public GameObject SceneGo { get; private set; }
    public LevelEntity CurLevel { get; private set; }

    public LevelSystem()
    {
        SceneGo = new GameObject("Scene");
    }

    public override void Start()
    {
        base.Start();
        CurLevel = GameObject.Find("Level1").GetComponent<LevelEntity>();
    }
}
