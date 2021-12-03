using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Model : MonoBehaviour
{
    IController _myController;
    private float baseHp = 3;
    private float _currentHp;

    #region MovementVariables
    [SerializeField]
    private float speed;
    private float moveInput;
    private Vector2 velocityVector;
    
    private Vector3 AuxScale;
    private bool isGrounded;
    [SerializeField]
    private GroundSensor    GroundSensor;
    [SerializeField]
    private LayerMask Ground;
    Rigidbody2D _rb;
    private bool facingRight = true;
    #endregion MovementVariables

    #region Events
    public event Action<float> onGetDmg = delegate { };
    public event Action onDeath = delegate { };
    public event Action<bool> onWalk = delegate { };
    public event Action<bool> onJump = delegate { };
    #endregion Events

    void Awake()
    {
        _currentHp = baseHp;
        _rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _myController = new Controller(this, GetComponent<View>());
    }

    void Update()
    {
        _myController.OnUpdate();
    }

    void FixedUpdate()
    {
        _myController.OnFixedUpdate();
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

    public void Movement()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        _rb.velocity = new Vector2(moveInput * speed, _rb.velocity.y);
        onWalk(!Mathf.Approximately(moveInput, 0f));
        onJump(!GroundSensor.IsGrounded());

        if(!facingRight && moveInput > 0)
        {
            FlipScale();
        }
        else if (facingRight && moveInput < 0)
        {
            FlipScale();
        }
    }

    public void UpdateMovement()
    {
        if (GroundSensor.IsGrounded() && Input.GetKeyDown(KeyCode.W))
        {
            _rb.velocity = Vector2.up * 21;
        }
    }

     private void FlipScale()
    {
        facingRight = !facingRight;
        AuxScale = transform.localScale;
        AuxScale.x = -AuxScale.x;
        transform.localScale = AuxScale;
    }
    
    public void Death()
    {
        Debug.Log("aia");
        onDeath();
    }
    
}
