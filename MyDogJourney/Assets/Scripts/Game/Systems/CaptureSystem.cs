using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TECS;
using TECS.Pooling;

public class CaptureSystem : TECSSystem<CaptureSystem>
{
    private GameObjectPool capturePool;
    private GameObject captureSrc;

    public CaptureSystem()
    {
        captureSrc = Resources.Load<GameObject>("Capture");
        capturePool = new GameObjectPool("CapturePool");
        capturePool.SetCreateFunc(CreateCaptureGO);
    }

    public void CreateCapture(PlayerEntity player)
    {
        GameObject capture = capturePool.Pop();
        capture.transform.position = player.transform.position;
    }

    private GameObject CreateCaptureGO()
    {
        return Object.Instantiate(captureSrc);
    }
}
