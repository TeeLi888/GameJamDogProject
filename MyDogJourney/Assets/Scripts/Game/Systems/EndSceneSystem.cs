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
    [SerializeField] private CanvasGroup txtGroup;
    [SerializeField] private Transform targetTr;
    [SerializeField] private Transform endFrameTr;

    public void Play(Transform endFrame)
    {
        PlayerInputSystem.Inst.locked = true;
        player.Freeze();
        endFrameTr.position = endFrame.position;
        endFrameTr.localScale = endFrame.localScale;
        endFrameTr.gameObject.SetActive(true);

        player.transform.SetParent(endFrameTr);
        player.SetToTop();

        CameraSystem.Inst.MainCamera.GetComponent<CameraFollow>().enabled = false;
        LevelSystem.Inst.CurLevel.ClearCaptures();

        StartCoroutine(EndRoutine());
    }

    private IEnumerator EndRoutine()
    {
        yield return new WaitForSeconds(1f);

        

        uiGroup.DOFade(0, 1f);
        endImg.gameObject.SetActive(true);
        endImg.color = new Color(1f, 1f, 1f, 0f);
        endImg.DOFade(1f, 5f).SetEase(Ease.Linear);
        endFrameTr.DOMove(targetTr.position, 4f).SetEase(Ease.Linear);
        endFrameTr.DOScale(targetTr.lossyScale, 4f).SetEase(Ease.Linear);

        yield return new WaitForSeconds(7f);
        txtGroup.gameObject.SetActive(true);
        txtGroup.DOFade(1f, 3f).SetEase(Ease.Linear);
    }
}
