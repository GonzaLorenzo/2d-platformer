using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHeart : MonoBehaviour
{
    Animator _myAnimator;

    void Awake()
    {
        _myAnimator = GetComponent<Animator>();
    }

    public void RemoveHeart(bool value)
    {
        _myAnimator.SetBool("RemoveHeart", value);
    }
}
