using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _velocity = new(-12f,0f);

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = _velocity;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EndBoom")|| collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            SpawnBoom.Push(gameObject);
        }
    }
}
