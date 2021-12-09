using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySensor : MonoBehaviour
{
    Rigidbody2D _rb;
    Model _thisModel;
    private float knockbackForce = 10f;

    void Start()
    {
        _rb = transform.parent.GetComponent<Rigidbody2D>();
        _thisModel = transform.parent.GetComponent<Model>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy HitEntity = collision.GetComponent<Enemy>();
        
        if(_thisModel.canKill)
        {
            if(HitEntity != null)
            {
                HitEntity.TakeDamage();
            }
            

            _rb.velocity = Vector2.zero;
            _rb.AddForce(Vector2.up * knockbackForce, ForceMode2D.Impulse);
        }
    }
}
