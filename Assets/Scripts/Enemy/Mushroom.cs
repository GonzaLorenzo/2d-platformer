using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Enemy
{
    Animator _myAnim;
    CapsuleCollider2D _myCollider;
    BoxCollider2D _myBoxCollider;
    void Awake()
    {
        _myAnim = GetComponent<Animator>();
        _myCollider = GetComponent<CapsuleCollider2D>();
        _myBoxCollider = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        Patrol();
    }

    public override void TakeDamage()
    {
        canMove = false;
        _myCollider.enabled = false;
        _myBoxCollider.enabled = false;
        AudioManager.instance.Play("EnemyDie");
        _myAnim.SetTrigger("IsDead");    
    }

    public void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }
}
