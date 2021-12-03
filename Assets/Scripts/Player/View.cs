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
                HealthIcons[i].enabled = true;
            }
            else
            {
                HealthIcons[i].enabled = false;
            }
        }
    }

    public void DeathMaterial()
    {
        _myMaterial.color = Color.red;
    }

    public void HurtAnimation()
    {
        _myAnimator.SetTrigger("Hurt");
    }

    public void DeathAnimation()
    {
        _myAnimator.SetTrigger("Death");
    }
}
