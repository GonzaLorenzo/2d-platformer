using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : IController
{
    protected IController _controller;

    public PowerUp(IController controller)
    {
        _controller = controller;
    }
    public void OnFixedUpdate()
    {
        
    }

    public void OnUpdate()
    {

    }
}
