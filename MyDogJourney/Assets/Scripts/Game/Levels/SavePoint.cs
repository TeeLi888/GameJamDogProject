using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public int id;
    [SerializeField] private Transform spawnPoint;

    public Vector3 GetPlayerSpawnPos()
    {
        return spawnPoint.position;
    }


}
