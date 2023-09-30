using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;

    // Start is called before the first frame update
    void Awake()
    {
        _animator= gameObject.GetComponent<Animator>();
        _rb= GetComponent<Rigidbody2D>();
        _sr= GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Personaje Ataca
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _animator.SetBool("isAttacking", true);
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            _animator.SetBool("isAttacking", false);
        }
        //Personaje se mueve a la derecha
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            _rb.velocity = new Vector2(1, 0);
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
            _rb.velocity = new Vector2(-1, 0);
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
                _rb.velocity = new Vector2(-2, 0);
            }
            else if (_sr.flipX == false)
            {
                _rb.velocity = new Vector2(2, 0);
            }
            _animator.SetBool("isRolling", true);

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _rb.velocity = Vector2.zero;
            _animator.SetBool("isRolling", false);
        }
        //Mecanica cambio gravedad
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            _sr.flipY = true;
            _rb.gravityScale = -1;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            _sr.flipY = false;
            _rb.gravityScale = 1;
        }
    }
}
