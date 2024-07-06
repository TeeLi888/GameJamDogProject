using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEntity : MonoBehaviour
{
    public virtual void OnLoad() { }

    public virtual void Begin() { }

    public virtual void Respawn(PlayerEntity player) { }
    public virtual void ResetLevel(PlayerEntity player) { }
    public virtual void AttachCapture(Capture capture) { }
    public virtual void ClearCaptures() { }
}
