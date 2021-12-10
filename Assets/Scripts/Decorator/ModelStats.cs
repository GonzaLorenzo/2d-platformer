using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelStats : ModelController
{
    public ModelStats()
    {
        _speed = 5f;
        _jumpForce = 7f;  
        _knockbackXForce = 11f;
        _knockbackYForce = 7f;   
    }

    private float _speed; //5
    private float _jumpForce; //0.35
    private float _knockbackXForce;
    private float _knockbackYForce;

    public override float GetSpeed()
    {
        return _speed;
    }
    public override float GetJumpForce()
    {
        return _jumpForce;
    }

    public override float GetKnockbackXForce()
    {
        return _knockbackXForce;
    }

    public override float GetKnockbackYForce()
    {
        return _knockbackYForce;
    }
}
