using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;
    private Transform _player;
    private SpriteRenderer _sr;
    public SoundManagerScript soundManager;
    private Vector2 respawn = new(-10, -15);
    private Vector2 respawn2 = new(7, -13);
    private Vector2 respawn3 = new(10, -15);

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb= GetComponent<Rigidbody2D>();
        _player = GetComponent<Transform>();
        _sr = GetComponent<SpriteRenderer>();
        soundManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManagerScript>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Debug.Log(CharacterAnimations.gravityActive);

            if (CharacterAnimations.gravityActive == false)
            {
                CharacterAnimations.FlipCharacter(_player);
                CharacterAnimations.gravityActive = true;
                _rb.gravityScale = 4;
                _animator.SetBool("isDeath", true);
                soundManager.PlaySFX(soundManager.death);
                _rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                StartCoroutine(respawnPlayer());
            }
            else //if (CharacterAnimations.gravityActive == true)
            {
                _animator.SetBool("isDeath", true);
                soundManager.PlaySFX(soundManager.death);
                _rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                StartCoroutine(respawnPlayer());
            }
        }
    }
    IEnumerator respawnPlayer()
    {
        yield return new WaitForSeconds(3);
        _rb.constraints = RigidbodyConstraints2D.None;
        _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        int sceneActual = SceneManager.GetActiveScene().buildIndex;
        switch (sceneActual)
        {
            case 0:
            case 1:
            case 2:
                _player.position = respawn;
                _rb.gravityScale = 4;
                break;
            case 3:
                _player.position = respawn2;
                _rb.gravityScale = -4;
                break;
            case 4:
            case 5:
                _player.position = respawn3;
                _rb.gravityScale = 4;
                break;
        }
        _animator.SetBool("isDeath", false);
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
{
   if (collision.GetComponent<spikes>())
   {
       Debug.Log("Detecta los pinchos");
       _animator.SetTrigger("death");
   }
}*/
}
