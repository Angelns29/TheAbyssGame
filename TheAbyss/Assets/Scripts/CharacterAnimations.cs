using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterAnimations : MonoBehaviour
{
    public static CharacterAnimations instance;
    
    private Animator _animator;
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;
    private Transform _tr;
    public SoundManagerScript soundManager;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    private float _horizontal;
    private float _vertical;
    private float _roll;
    private float _speed;
    public static int _gravity;
    public static bool _isFacingRight;
    public static bool gravityActive = true;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);


        _animator = gameObject.GetComponent<Animator>();
        _rb= GetComponent<Rigidbody2D>();
        _sr= GetComponent<SpriteRenderer>();
        _tr = GetComponent<Transform>();
        soundManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManagerScript>();

        _speed = 14f;
        _gravity = 4;
        _rb.gravityScale = _gravity;
        _isFacingRight = true;
    }
    // Update is called once per frame
    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
        _roll = Input.GetAxisRaw("Roll");
        Flip();

        //Animacion Personaje Corriendo
        if (_horizontal != 0) _animator.SetBool("isRunning", true);
        else _animator.SetBool("isRunning", false);

        //Personaje Ataca
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            _animator.SetBool("isAttacking", true);
            soundManager.PlaySFX(soundManager.attack);
        }
        if (Input.GetKeyUp(KeyCode.Z) || Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            _animator.SetBool("isAttacking", false);
        }

        //Esquive
        if (_roll != 0)
        {
            _animator.SetBool("isRunning", false);
            _animator.SetBool("isRolling", true);
        }
        else
        {
            _animator.SetBool("isRolling", false);
            //_animator.SetBool("isRunning", true);
        }

        
        //Cambio Gravedad
        if (_vertical == 1 && IsGrounded())
        {
            if (gravityActive)
            {
                ChangeGravity();
                gravityActive = false;
            }
        }
        else if (_vertical == -1 && IsGrounded())
        {
            if (gravityActive == false)
            {
                ChangeGravity();
                gravityActive = true;
            }
        }

    }
    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_horizontal * _speed, _rb.velocity.y);
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
    }
    public  void Flip()
    {
        if (_isFacingRight && _horizontal < 0f || !_isFacingRight && _horizontal > 0f)
        {
            _isFacingRight = !_isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    public void ChangeGravity()
    {
        soundManager.PlaySFX(soundManager.jump);
        _isFacingRight = !_isFacingRight;
        _tr.Rotate(0, 0, 180);
        _gravity *= -1;
        _rb.gravityScale = _gravity;
    }
}