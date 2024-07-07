using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TECS;
using DG.Tweening;

public class EndSceneSystem : TECSMonoSystem<EndSceneSystem>
{
    [SerializeField] private SpriteRenderer endImg;
    [SerializeField] private PlayerEntity player;
    [SerializeField] private CanvasGroup uiGroup;

    public void Play()
    {
        PlayerInputSystem.Inst.locked = true;
        player.Freeze();

        TimingSystem.Inst.RunOnce("enddelay", 1f, () =>
        {
            uiGroup.DOFade(0, 1f);
            endImg.gameObject.SetActive(true);
            endImg.color = new Color(1f, 1f, 1f, 0f);
            endImg.DOFade(1f, 5f).SetEase(Ease.Linear);
        });
    }
}
