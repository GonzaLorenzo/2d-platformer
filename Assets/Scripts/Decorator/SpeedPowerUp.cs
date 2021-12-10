using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : ModelDecorator
{
    public SpeedPowerUp(ModelController modelController) : base(modelController)
    {
    }

    public override float GetJumpForce()
    {
        return _modelController.GetJumpForce();
    }

    public override float GetKnockbackXForce()
    {
        return _modelController.GetKnockbackXForce();
    }

    public override float GetKnockbackYForce()
    {
        return _modelController.GetKnockbackYForce();
    }

    public override float GetSpeed()
    {
        return _modelController.GetSpeed() * 2f;
    }
}
