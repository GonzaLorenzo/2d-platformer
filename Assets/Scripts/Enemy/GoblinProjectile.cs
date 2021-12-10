using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinProjectile : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D   _rb;
    [SerializeField]
    private float       speed = 2.5f;
    
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        _rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
    }

    public void SetDestination(Vector2 destination)
    {
        transform.up = destination;
    }

}
