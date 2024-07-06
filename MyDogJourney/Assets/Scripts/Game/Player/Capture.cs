using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capture : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRd;

    public void SetCapture(PlayerEntity player)
    {
        transform.position = player.GetSpritePos();
        spriteRd.sprite = player.GetSprite();
    }
}
