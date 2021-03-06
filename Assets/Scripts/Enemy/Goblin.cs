using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy
{
    Animator _myAnim;
    [SerializeField]
    private GoblinProjectile shotPrefab;
    [SerializeField]
    private Transform shotPoint;
    public LayerMask targetMask;
    public LayerMask obstacleMask;
    private float _viewRadius = 15f;
    private Collider2D _target;
    private bool canShoot = false;
    private float _timePassed;
    private float _shootTime = 1.5f;
    private Vector2 YOffset = new Vector2(0,0.4f);
    private GameObject parent;
    void Start()
    {
        parent = GameObject.Find("MainGame");
        _timePassed = _shootTime;
        _myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {     
        FieldOfView();
        //Shoot();
    }

    public override void TakeDamage()
    {
        
    }

    public void FieldOfView()
    {
        Collider2D[] myTarget = Physics2D.OverlapCircleAll(transform.position, _viewRadius, targetMask);

        foreach (var item in myTarget)
        {
            _target = item; 
            Debug.Log("Detecto");
        }  

        if(_target != null)
        {
            Vector2 dir = _target.transform.position - transform.position;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, dir.magnitude, obstacleMask);

            if(hit == false)
            {
                canShoot = true;
                _myAnim.SetBool("IsAttacking", true);
            }
        }
        else
        {
            canShoot = false;
            _myAnim.SetBool("IsAttacking", false);
        }
    }

    public void Shoot()
    {
        if(canShoot)
        {
            //if(_timePassed > 0)
            //{
            //    _timePassed -= Time.deltaTime;
            //}
            //else
            //{
                Vector2 dir = _target.transform.position - transform.position;
                GoblinProjectile createdProjectile = Instantiate<GoblinProjectile>(shotPrefab, shotPoint.position, Quaternion.identity, parent.transform);
                createdProjectile.SetDestination(dir + YOffset);
                //_timePassed = _shootTime;
                
            //}
           
        }
        
    }
}

