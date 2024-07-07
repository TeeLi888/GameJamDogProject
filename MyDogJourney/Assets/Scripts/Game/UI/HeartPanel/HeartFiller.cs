using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartFiller : MonoBehaviour
{
    [SerializeField] private GameObject filler;
    public void SetFill(bool isOn)
    {
        bool oldIsOn = gameObject.activeSelf;
        gameObject.SetActive(isOn);
        if ((!oldIsOn) && isOn)
        {
            transform.DOKill();
            transform.localScale = Vector3.zero;
            transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.Linear);
        }
    }
}
