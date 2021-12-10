using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Model : MonoBehaviour
{
    IController _myController;
    private float baseHp = 3;
    private float _currentHp;
    public bool canKill = true;
    #region MovementVariables
    [SerializeField]
    private float speed;
    private float moveInput;
    private Vector2 velocityVector;
    [SerializeField]
    private float jumpForce;
    private Vector3 AuxScale;
    private bool isGrounded;
    [SerializeField]
    private GroundSensor GroundSensor;
    private float jumpTimeCounter;
    [SerializeField]
    private float jumpTime;
    private LayerMask Ground;
    Rigidbody2D _rb;
    private bool isJumping;
    private bool facingRight = true;
    private bool canMove = true;
    #endregion MovementVariables

    #region Events
    public event Action<float> onGetDmgHUD = delegate { };
    public event Action<bool> onGetDmg = delegate { };
    public event Action onDeath = delegate { };
    public event Action<bool> onWalk = delegate { };
    public event Action<bool> onJump = delegate { };
    #endregion Events

    private float KnockbackXForce = 11f;
    private float KnockbackYForce = 7f;
    private float knockbackTime = 0.4f;

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

        onGetDmgHUD(_currentHp);

        if(_currentHp <= 0)
        {
            Death();
            _rb.velocity = Vector2.zero;
        }
        else
        {
            StartCoroutine(DoKnockback(knockbackTime));
        }
    }

    public void Movement()
    {
        if(canMove)
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
    }

    public void UpdateMovement()
    {
        if(canMove)
        {
            if (GroundSensor.IsGrounded() && Input.GetKeyDown(KeyCode.W))
            {
                isJumping = true;
                jumpTimeCounter = jumpTime;
                _rb.velocity = Vector2.up * jumpForce;
            }

            if (Input.GetKey(KeyCode.W) && isJumping)
            {
                if(jumpTimeCounter > 0)
                {
                    _rb.velocity = Vector2.up * jumpForce;
                    jumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    isJumping = false;
                }     
            }
            
            if(Input.GetKeyUp(KeyCode.W))
            {
                isJumping = false;
            }    

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                var screenPause = Instantiate(Resources.Load<ScreenPause>("PauseCanvas"));
                ScreenManager.Instance.Push(screenPause);
            }    
        }
    }

     private void FlipScale()
    {
        facingRight = !facingRight;
        AuxScale = transform.localScale;
        AuxScale.x = -AuxScale.x;
        transform.localScale = AuxScale;
    }
    
    public void AddLife(float dmg)
    {
        _currentHp += dmg;
        if(_currentHp > 3)
        {
            _currentHp = 3;
        }
        onGetDmgHUD(_currentHp);
    }

    public void Death()
    {
        canMove = false;
        onDeath();   
    }
    
    public IEnumerator DoKnockback(float knockbackTime)
    {
        onGetDmg(true);   
        canMove = false;
        canKill = false;
        _rb.velocity = Vector2.zero;

        float knockX = Mathf.Sign(moveInput);
   
        _rb.AddForce(new Vector2(-knockX*KnockbackXForce,KnockbackYForce),ForceMode2D.Impulse);

        yield return new WaitForSeconds(knockbackTime);
        _rb.velocity = Vector2.zero;
        canKill = true;
        canMove = true;
        onGetDmg(false); 
    }
    
}
