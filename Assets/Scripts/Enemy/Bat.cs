using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemy
{
    Animator _myAnim;
    private float _timePassed;
    private float _shootTime = 1.5f;
    [SerializeField]
    private Projectile shotPrefab;
    [SerializeField]
    private Transform shotPoint;
    void Awake()
    {
        _myAnim = GetComponent<Animator>();    
    }

    void Update()
    {
        Patrol();

        if(_timePassed > 0)
        {
            _timePassed -= Time.deltaTime;
        }
        else
        {
            Projectile newProjectile = Instantiate<Projectile>(shotPrefab, shotPoint.position, Quaternion.identity);
            _timePassed = _shootTime;
        }

    }

    public override void TakeDamage()
    {

    }
}
