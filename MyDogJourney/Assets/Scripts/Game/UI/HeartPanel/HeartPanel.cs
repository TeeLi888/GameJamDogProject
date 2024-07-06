using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPanel : MonoBehaviour
{
    public static HeartPanel Inst { get; private set; }
    [SerializeField] private List<HeartFiller> fillers;


    private void Awake()
    {
        Inst = this;
    }

    public void SetHeart(int count)
    {
        for(int i = 0; i < fillers.Count; i++)
        {
            fillers[i].SetFill(i < count);
        }
    }
}
