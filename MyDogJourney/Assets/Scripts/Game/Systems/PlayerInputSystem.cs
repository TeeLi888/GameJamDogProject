using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TECS;

public class PlayerInputSystem : TECSMonoSystem<PlayerInputSystem>
{
    public Vector2 axis;
    public bool isJump;
    public bool isCapture;

    public override void Update()
    {
        base.Update();
        float axisx = Input.GetAxis("Horizontal");
        float axisy = Input.GetAxis("Vertical");
        axis = new Vector2(axisx, axisy);

        isJump = Input.GetKeyDown(KeyCode.Space);
        isCapture = Input.GetKeyDown(KeyCode.K);
    }
}
