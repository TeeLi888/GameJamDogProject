using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonLevelEntity : LevelEntity
{
    public SavePoint savePoint;

    public override void Respawn(PlayerEntity player)
    {
        base.Respawn(player);
        player.transform.position = savePoint.GetPlayerSpawnPos();
        player.OnRespawn();
    }
}
