using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField]
    private int DamageAmount = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       Model HitEntity = collision.GetComponent<Model>();
        
        if(HitEntity != null)
        {
            HitEntity.TakeDamage(DamageAmount);
        }       
    }
}