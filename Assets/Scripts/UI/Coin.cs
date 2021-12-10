using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Animator myAnimator;
    static public int CollectedAmount;
    [SerializeField]
    private int CoinValue = 1;

    private void Awake()
    {
        myAnimator = this.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollectedAmount += CoinValue;
        AudioManager.instance.Play("CoinSound");
        myAnimator.SetTrigger("DestroyCoin");
    }

    public void DestroyCoin()
    {
        Destroy(this.gameObject);
    }
    

        
}