using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndFrame : Frame
{
    public override void Activate(bool isShow)
    {
        base.Activate(isShow);
        Debug.Log("ShowEnd");
    }
}
