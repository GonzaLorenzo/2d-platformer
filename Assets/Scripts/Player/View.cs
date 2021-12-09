using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    [SerializeField]
    private Image[] HealthIcons;
    Material _myMaterial;
    Animator _myAnimator;

    void Start()
    {
        _myMaterial = GetComponent<Renderer>().material;
        _myAnimator = GetComponent<Animator>();
    }

    public void UpdateHudLife(float value)
    {
        //lifeBar.fillAmount = value;

        for (int i = 0; i < (HealthIcons.Length); i++) 
        {
            if (i < value)
            {
                HealthIcons[i].GetComponent<UIHeart>().RemoveHeart(false);
            }
            else
            {
                HealthIcons[i].GetComponent<UIHeart>().RemoveHeart(true);
            }
        }
    }

    public void DeathMaterial()
    {
        _myMaterial.color = Color.red;
    }

    public void HurtAnimation(bool value)
    {
        _myAnimator.SetBool("IsHurt", value);
    }

    public void DeathAnimation()
    {
        _myAnimator.SetBool("IsDead", true);
    }

    public void WalkAnimation(bool value)
    {
        _myAnimator.SetBool("IsWalking", value);
    }

    public void JumpAnimation(bool value)
    {
        _myAnimator.SetBool("IsJumping", value);
    }
}
