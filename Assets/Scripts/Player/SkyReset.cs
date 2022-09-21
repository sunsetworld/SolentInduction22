using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyReset : MonoBehaviour
{
    [SerializeField] private Vector3 originalLocation;
    // Start is called before the first frame update
    void Start()
    {
        originalLocation = transform.position; // Sets the originalLocation variable.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Reset")) // If the player collides with the in-game trigger.
        {
            ResetPlayer();
        }
    }

    void ResetPlayer()
    {
        transform.position = originalLocation; // Resets the player's location.
    }
    
    
}
