using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartFiller : MonoBehaviour
{
    [SerializeField] private GameObject filler;
    public void SetFill(bool isOn)
    {
        filler.SetActive(isOn);
    }
}
