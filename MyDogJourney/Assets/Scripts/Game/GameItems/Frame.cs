using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour
{
    [SerializeField] private GameObject sceneGo;
    [SerializeField] private Collider2D sceneCollid;
    [SerializeField] private SpriteRenderer bodyRd;
    [SerializeField] private GameObject collidGo;

    private void Start()
    {
        Activate(false);
    }

    public virtual void Activate(bool isShow)
    {
        var allSprites = sceneGo.GetComponentsInChildren<SpriteRenderer>();
        foreach (var sprite in allSprites) 
        {
            sprite.color = isShow ? Color.white : new Color(1f, 1f, 1f, 0.6f);
        }

        bodyRd.color = isShow ? Color.white : new Color(1f, 1f, 1f, 0.78f);

        if (sceneCollid)
        {
            sceneCollid.enabled = isShow;
        }

        if (collidGo)
        {
            collidGo.gameObject.SetActive(isShow);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerEntity player = collision.GetComponentInParent<PlayerEntity>();
        if (player)
        {
            player.OnEnterFrame(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerEntity player = collision.GetComponentInParent<PlayerEntity>();
        if (player)
        {
            player.OnExitFrame(this);
        }
    }
}
