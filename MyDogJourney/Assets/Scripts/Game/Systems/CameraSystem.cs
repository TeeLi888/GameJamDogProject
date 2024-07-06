using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TECS;

public class CameraSystem : TECSSystem<CameraSystem>
{
    public Camera MainCamera { get; private set; }
    public CameraSystem()
    {
        MainCamera = Camera.main;
    }
}
