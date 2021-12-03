using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Model : MonoBehaviour
{
    [SerializeField]
    private float baseHp = 3;
    private float _currentHp;

    IController _myController;

    public event Action<float> onGetDmg = delegate { };
    public event Action onDeath = delegate { };

    void Awake()
    {
        _currentHp = baseHp;
    }

    void Start()
    {
        _myController = new Controller(this, GetComponent<View>());
    }

    public void TakeDamage(float dmg)
    {
        _currentHp -= dmg;

        onGetDmg(_currentHp);

        if(_currentHp <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Debug.Log("aia");
        onDeath();
    }
    
}
