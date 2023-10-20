using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Animator _animator;
    [HideInInspector]
    public bool isActive;
    public void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void Activate()
    {
        isActive = true;
        _animator.SetBool("isActive", true);
    }
    public void Deactivate()
    {
        isActive = false;
        _animator.SetBool("isActive", false);
    }

}
