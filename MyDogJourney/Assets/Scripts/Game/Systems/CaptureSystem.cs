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

    public Capture CreateCapture(PlayerEntity player)
    {
        GameObject captureGo = capturePool.Pop();
        captureGo.transform.position = player.transform.position;
        Capture capture = captureGo.GetComponent<Capture>();
        capture.SetCapture(player);
        LevelSystem.Inst.CurLevel.AttachCapture(capture);
        return capture;
    }

    public void ReturnCapture(Capture capture)
    {
        capturePool.Add(capture.gameObject);
    }

    private GameObject CreateCaptureGO()
    {
        return Object.Instantiate(captureSrc);
    }
}
