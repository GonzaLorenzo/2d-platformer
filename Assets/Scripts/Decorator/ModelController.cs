using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ModelController 
{
    public abstract float GetSpeed();
    public abstract float GetJumpForce();
    public abstract float GetKnockbackXForce();
    public abstract float GetKnockbackYForce();
}
