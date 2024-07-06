using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public int id;
    public bool isTouched;
    [SerializeField] private Animator flagAnimator;
    [SerializeField] private Transform spawnPoint;

    public Vector3 GetPlayerSpawnPos()
    {
        return spawnPoint.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponentInParent<PlayerEntity>())
        {
            if (!isTouched)
            {
                isTouched = true;
                PlayFalgAnim();
                LevelSystem.Inst.CurLevel.OnSavePoint(this);
            }
        }
        
    }

    private void PlayFalgAnim()
    {
        flagAnimator.Play("Flag_start");
    }
}
