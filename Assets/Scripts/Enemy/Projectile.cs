using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector2 Speed;
    private Rigidbody2D MyRigidbody2D;

    private void Start()
    {
        //MyRigidbody2D.velocity = Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }

}
