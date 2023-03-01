using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    public float speed = 5f;
    public bool  isSprinting = false;
    public float sprintingMultiplier;
    public float JumpSpeed = 8f; 
    private float direction = 0f;
    private new Camera camera; 

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundlayer;
    private bool isTouchingGround; 

    private Rigidbody player; 
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
        direction = Input.GetAxis("Horizontal");

        Collider col = GetComponent<Collider>();
        float halfheight = col.bounds.extents.y + 0.03f;

       
        
        
       
        
        isTouchingGround = Physics.Raycast(transform.position, Vector3.down, halfheight);
        player.velocity = new Vector3(Mathf.Clamp(player.velocity.x, -speed, speed), player.velocity.y,
            player.velocity.z);
        
        if (direction > 0f)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                player.velocity = new Vector3(direction * sprintingMultiplier, player.velocity.y, 0f);
            }
            else
            {
                player.velocity = new Vector3(direction * speed, player.velocity.y, 0f);
                            transform.eulerAngles = new Vector3(0f, 90f, 0f);
            }
            
        }
        else if (direction < 0f)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                player.velocity = new Vector3(direction * sprintingMultiplier, player.velocity.y, 0f);
            }
            else
            {
                player.velocity = new Vector3(direction * speed, player.velocity.y, 0f);
                            transform.eulerAngles = new Vector3(0f, 270f, 0f);
            }
            
        }
        else
        {
            player.velocity = new Vector3(0, player.velocity.y, 0f);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            player.velocity = new Vector3(player.velocity.x, JumpSpeed);
        }

        float runspeed = player.velocity.magnitude;

        Animator animator = GetComponent<Animator>(); 
        
        animator.SetFloat("Speed", runspeed);
        animator.SetBool("isJumping", !isTouchingGround);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Brick"))
        {
            
            
        }
    }

   
    
}
