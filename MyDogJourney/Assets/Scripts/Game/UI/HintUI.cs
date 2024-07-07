using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintUI : MonoBehaviour
{
    [SerializeField] private SpriteRenderer rd;
    public float fadeTime;
    public bool isShow;
    

    private void Start()
    {
        Color color = rd.color;
        color.a = 0;
        rd.color = color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isShow) return;
        if (collision.GetComponentInParent<PlayerEntity>())
        {
            isShow = true;
            rd.DOFade(1, fadeTime).SetEase(Ease.OutCubic);
        }
    }
}
