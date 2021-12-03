using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : IController
{
    Model _m; 

    public Controller (Model m, View v)
    {
        _m = m;

        _m.onGetDmg += v.UpdateHudLife;
        _m.onDeath += v.DeathMaterial;
        _m.onDeath += v.DeathAnimation;
        _m.onWalk += v.WalkAnimation;
        _m.onJump += v.JumpAnimation;
    }

    public void OnUpdate()
    {
        _m.UpdateMovement();
    }

    public void OnFixedUpdate()
    {
        _m.Movement();
    } 
}
