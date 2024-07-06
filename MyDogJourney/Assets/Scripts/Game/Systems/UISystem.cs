using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TECS;
using UnityEngine;
using UnityEngine.UI;

public class UISystem : TECSMonoSystem<UISystem>
{
    [SerializeField] private Image cutPicture;

    public void PlayCutPictureEffect(Action callback)
    {
        cutPicture.gameObject.SetActive(true);
        cutPicture.color=new Color(1f, 1f, 1f,0.5F);

        Sequence sequence = DOTween.Sequence();

        sequence.Append(cutPicture.DOFade(0.8f, 0.05f).SetEase(Ease.InCubic))
                .Append(cutPicture.DOFade(0, 0.2f).SetEase(Ease.OutCubic))
                .OnComplete(() =>
                {
                    cutPicture.gameObject.SetActive(false);
                    callback?.Invoke();
                });
    }
}
