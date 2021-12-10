using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour, IObservable
{
    IObserver _myObserver;
    private float waitTime = 1.5f;
    [SerializeField]
    private CanvasManager canvasManager;
    [SerializeField]
    private Image[] HealthIcons;
    Material _myMaterial;
    Animator _myAnimator;

    void Awake()
    {
        Subscribe(canvasManager);
    }

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

    public void DeathUI()
    {
        StartCoroutine(NotifyMyObserver(waitTime));
    }

    public void WalkAnimation(bool value)
    {
        _myAnimator.SetBool("IsWalking", value);
    }

    public void JumpAnimation(bool value)
    {
        _myAnimator.SetBool("IsJumping", value);
    }

    public void NotifyToObservers(string action)
    {
        _myObserver.Notify(action);
    }

    public void Subscribe(IObserver obs)
    {
        if (_myObserver == null)
        {
            _myObserver = obs;
        }
    }

    public void Unsubscribe(IObserver obs)
    {
        if (_myObserver != null)
        {
            _myObserver = null;
        }
    }

    private IEnumerator NotifyMyObserver(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        NotifyToObservers("PlayerLost");
    }
}
