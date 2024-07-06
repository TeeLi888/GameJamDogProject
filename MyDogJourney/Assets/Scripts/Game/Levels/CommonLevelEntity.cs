using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonLevelEntity : LevelEntity
{
    public SavePoint savePoint;

    private List<Capture> captures = new List<Capture>();
    

    public override void Respawn(PlayerEntity player)
    {
        base.Respawn(player);
        player.transform.position = savePoint.GetPlayerSpawnPos();
        player.OnRespawn();
    }

    public override void ResetLevel(PlayerEntity player)
    {
        base.ResetLevel(player);
        ClearCaptures();
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
}
