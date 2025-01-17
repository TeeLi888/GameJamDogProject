using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TECS;

public class PlayerInputSystem : TECSMonoSystem<PlayerInputSystem>
{
    public Vector2 axis;
    public bool isJump;
    public bool isCapture;

    public bool locked = false;

    public override void Update()
    {
        base.Update();

        if (locked)
        {
            axis = Vector2.zero;
            isJump = false;
            isCapture = false;
        }
        else
        {
            float axisx = Input.GetAxis("Horizontal");
            float axisy = Input.GetAxis("Vertical");
            axis = new Vector2(axisx, axisy);

            isJump = Input.GetKeyDown(KeyCode.Space);
            isCapture = Input.GetMouseButtonDown(0);
        }
    }
}
