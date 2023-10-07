using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;
    private Transform _player;
    private SpriteRenderer _sr;
    public SoundManagerScript soundManager;
    private Vector2 respawn = new Vector2(-10, -15);
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
            _rb.gravityScale = 4;
            _sr.flipY = false;
            _animator.SetBool("isDeath", true);
            soundManager.PlaySFX(soundManager.death);
            StartCoroutine(respawnPlayer());
        }
    }
    IEnumerator respawnPlayer()
    {
        yield return new WaitForSeconds(5);
        _player.position = respawn;
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
