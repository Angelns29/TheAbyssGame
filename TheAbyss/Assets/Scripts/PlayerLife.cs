using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;
    private Transform _player;
    private SpriteRenderer _sr;
    public SoundManagerScript soundManager;
    private Vector3 previusCheckpoint;
    private RigidbodyConstraints2D originalRb = RigidbodyConstraints2D.FreezeRotation;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb= GetComponent<Rigidbody2D>();
        _player = GetComponent<Transform>();
        _sr = GetComponent<SpriteRenderer>();
        soundManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManagerScript>();
        previusCheckpoint = GetCheckpoint();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            //Debug.Log(CharacterAnimations.gravityActive);

            if (CharacterAnimations.gravityActive == false)
            {
                CharacterAnimations.gravityActive = true;
                ChangeGravity();
                _animator.SetBool("isDeath", true);
                soundManager.PlaySFX(soundManager.death);
                _rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                StartCoroutine(respawnPlayer());
            }
            else
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
        yield return new WaitForSeconds(2);
        _rb.constraints = originalRb;
        _player.position = GetCheckpoint();
        _rb.gravityScale = 4;
        _animator.SetBool("isDeath", false);
    }
    public static void FlipCharacter(Transform player)
    {
        Vector2 scaler = player.localScale;
        scaler.y *= -1;
        player.localScale = scaler;
    }
    public void ChangeGravity()
    {
        CharacterAnimations._isFacingRight = !CharacterAnimations._isFacingRight;
        _player.Rotate(0, 0, 180);
        CharacterAnimations._gravity *= -1;
        _rb.gravityScale = CharacterAnimations._gravity;
    }
    public Vector3 GetCheckpoint()
    {
        GameObject checkpoint = GameObject.Find("Checkpoint");
        if (checkpoint != null)
        {
            return checkpoint.transform.position;
            //player.position = new Vector3(-10,-15,0);//GameController.activeCheckpoint.position;
        }
        else
        {
            Debug.LogError("No se encontro el Checkpoint");
            return previusCheckpoint;
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            Checkpoint checkpoint = collision.gameObject.GetComponent<Checkpoint>();
            checkpoint.Activate();
        }
    }
}
