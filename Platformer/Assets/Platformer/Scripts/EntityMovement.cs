using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private new Rigidbody _rb;
    public float speed = 1f;

    private Vector3 velocity; 
    private float direction = -1f;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        enabled = false;
    }

    private void OnBecameVisible()
    {
        enabled = true;
    }

    private void OnBecameInvisible()
    {
        enabled = false;
    }

    private void onEnable()
    {
        _rb.WakeUp();
    }

    private void OnDisable()
    {
        _rb.velocity = new Vector3(0f, 0f, 0f);
        _rb.Sleep();
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector3(direction * speed, 0f, 0f);
        
        _rb.MovePosition(_rb.position + velocity * Time.fixedDeltaTime);
        
        
    }
}
