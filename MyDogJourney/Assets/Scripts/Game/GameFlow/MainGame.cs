using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame
{
    public void Start()
    {
        CameraSystem.Create();
        LevelSystem.Create();
        CaptureSystem.Create();

        LevelSystem.Inst.Start();
    }

    public void Update()
    {

    }
}
