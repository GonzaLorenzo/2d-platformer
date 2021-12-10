using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackPowerUp : ModelDecorator
{
    public KnockbackPowerUp(ModelController modelController) : base(modelController)
    {
    }

    public override float GetJumpForce()
    {
        return _modelController.GetJumpForce();
    }

    public override float GetKnockbackXForce()
    {
        return _modelController.GetKnockbackXForce() * 0.2f;
    }

    public override float GetKnockbackYForce()
    {
        return _modelController.GetKnockbackYForce() * 0.2f;
    }

    public override float GetSpeed()
    {
        return _modelController.GetSpeed();
    }
}
