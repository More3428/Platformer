using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite flatSprite;
    private bool topofHead;

    private void OnCollisionEnter(Collision collision)
    {
        Collider col = GetComponent<Collider>();
        float halfheight = col.bounds.extents.y + 0.03f;
        topofHead = Physics.Raycast(transform.position, Vector3.down, halfheight);
        if (collision.gameObject.CompareTag("Player") && topofHead)
        {
            
                Flatten();
            
        }
    }

    private void Flatten()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<EntityMovement>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = flatSprite;
        Destroy(gameObject, 0.5f);
        
    }
}
