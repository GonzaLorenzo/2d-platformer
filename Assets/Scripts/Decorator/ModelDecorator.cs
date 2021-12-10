using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ModelDecorator : ModelController
{
    protected ModelController _modelController;

    public ModelDecorator(ModelController modelController)
    {
        _modelController = modelController;
    }
}
