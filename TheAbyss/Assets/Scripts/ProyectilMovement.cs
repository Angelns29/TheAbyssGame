using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilMovement : MonoBehaviour
{
    private Transform _tr;
    private Rigidbody2D _rb;
    private Vector2 _velocity = new(-12f,0f);
    public Transform spawnUP;
    public Transform spawnDown;
    private SoundManagerScript _soundManager;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _tr =  GetComponent<Transform>();
        GameObject go = GameObject.Find("SoundManager");
        _soundManager= go.GetComponent<SoundManagerScript>();
    }
    public void Move()
    {
        _rb.velocity = _velocity;
        _soundManager.PlaySFX(_soundManager.bombSound);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EndBoom"))
        {
            if (_tr.name == "BombUp")
            {
                _tr.position = spawnUP.position;
            }
            else if (_tr.name == "BombDown")
            {
                _tr.position = spawnDown.position;
            }
        }
    }
}
