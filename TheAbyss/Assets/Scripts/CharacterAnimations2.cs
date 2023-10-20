using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterAnimations2 : MonoBehaviour
{
    public static CharacterAnimations2 instane2;
    public static bool gravityActive = true;

    private Animator _animator;
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;
    private Transform _tr;

    public SoundManagerScript soundManager;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    private float _horizontal;
    private float _speed;
    public static int gravity;
    public static bool isFacingRight;


    // Start is called before the first frame update
    void Awake()
    {
        if (instane2 == null)
        {
            instane2 = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
        _animator = gameObject.GetComponent<Animator>();
        _rb= GetComponent<Rigidbody2D>();
        _sr= GetComponent<SpriteRenderer>();
        _tr = GetComponent<Transform>();
        soundManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManagerScript>();

        _speed = 14f;
        gravity = 4;
        _rb.gravityScale = gravity;
        isFacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        FlipCharacter();
        //AnimacionMovimiento
        if (_horizontal != 0) _animator.SetBool("isRunning", true);
        else _animator.SetBool("isRunning", false);
        //Personaje Ataca
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _animator.SetBool("isAttacking", true);
            soundManager.PlaySFX(soundManager.attack);
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            _animator.SetBool("isAttacking", false);
        }
        //Esquive
        if (Input.GetKeyDown(KeyCode.Space))
        {
            /*if (_sr.flipX == true)
            {
                _rb.velocity = new Vector2(-4, 0);
            }
            else if (_sr.flipX == false)
            {
                _rb.velocity = new Vector2(4, 0);
            }*/
            _animator.SetBool("isRunning", false);
            _animator.SetBool("isRolling", true);

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //_rb.velocity = Vector2.zero;
            _animator.SetBool("isRolling", false);
            _animator.SetBool("isRunning", true);
        }
        if ((Input.GetKeyDown(KeyCode.UpArrow) || UnityEngine.Input.GetKeyDown(KeyCode.Joystick1Button0)) && IsGrounded())
        {
            ChangeGravity();
        }
        if ((Input.GetKeyDown(KeyCode.DownArrow) || UnityEngine.Input.GetKeyDown(KeyCode.Joystick1Button0)) && IsGrounded())
        {
            ChangeGravity();
        }
        /*
        //Personaje Ataca
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _animator.SetBool("isAttacking", true);
            soundManager.PlaySFX(soundManager.attack);
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            _animator.SetBool("isAttacking", false);
        }
        //Personaje se mueve a la derecha
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            _rb.velocity = new Vector2(4, 0);
            _animator.SetBool("isRunning", true);
            _sr.flipX = false;

        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            _rb.velocity = Vector2.zero;
            _animator.SetBool("isRunning", false);

        }
        //Personaje se mueve a la izquierda
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            _rb.velocity = new Vector2(-4, 0);
            _sr.flipX = true;
            _animator.SetBool("isRunning", true);

        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            _rb.velocity = Vector2.zero;
            _animator.SetBool("isRunning", false);

        }
        //Esquive
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_sr.flipX == true)
            {
                _rb.velocity = new Vector2(-4, 0);
            }
            else if (_sr.flipX == false)
            {
                _rb.velocity = new Vector2(4, 0);
            }
            _animator.SetBool("isRolling", true);

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _rb.velocity = Vector2.zero;
            _animator.SetBool("isRolling", false);
        }
        //Mecanica cambio gravedad
        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
        {
            //_sr.flipY = true;
            if (gravityActive == true)
            {
                FlipCharacter(_tr);
                _rb.gravityScale = -4; 
                gravityActive = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && IsGrounded())
        {

            if (gravityActive == false)
           {
                FlipCharacter(_tr);
                //_sr.flipY = false;
                _rb.gravityScale = 4;
                gravityActive=true;
            }
        }*/
    }
    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_horizontal * _speed, _rb.velocity.y);
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
    }
    public void FlipCharacter()
    {
        if (isFacingRight && _horizontal < 0f || !isFacingRight && _horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    public void ChangeGravity()
    {
        isFacingRight = !isFacingRight;
        _tr.Rotate(0, 0, 180);
        gravity *= -1;
        _rb.gravityScale = gravity;
    }
    
}