using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonLevelEntity : LevelEntity
{
    public SavePoint savePoint;

    private List<Capture> captures = new List<Capture>();

    public SavePoint CurSavePoint { get; set; }

    private void Start()
    {
        CurSavePoint = savePoint;
    }


    public override void Respawn(PlayerEntity player)
    {
        base.Respawn(player);
        player.transform.position = CurSavePoint.GetPlayerSpawnPos();
        player.OnRespawn();
    }

    public override void ResetLevel(PlayerEntity player)
    {
        base.ResetLevel(player);
        ClearCaptures();
        ResetFrames();
        player.OnLevelReset();
        Respawn(player);
    }

    public override void AttachCapture(Capture capture)
    {
        base.AttachCapture(capture);
        captures.Add(capture);
    }

    public override void ClearCaptures()
    {
        base.ClearCaptures();
        for(int i = 0; i < captures.Count; i++)
        {
            CaptureSystem.Inst.ReturnCapture(captures[i]);
        }
    }

    public override void OnSavePoint(SavePoint point)
    {
        base.OnSavePoint(point);
        CurSavePoint = point;
    }

    private void ResetFrames()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).TryGetComponent(out Frame frame))
            {
                frame.Activate(false);
            }
        }
    }
}
