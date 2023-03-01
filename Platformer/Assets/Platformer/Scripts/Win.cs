using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    // Start is called before the first frame update
     private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                
                Debug.Log("Completed Level 1-1!");
                GameManager.Instance.ResetLevel(6f);
            }
            
        }
}
