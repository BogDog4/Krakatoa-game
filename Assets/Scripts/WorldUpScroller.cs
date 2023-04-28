using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldUpScroller : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player object's transform component
    private float normalSpeed = .5f; // The speed at which the world scrolls upward by default
    private float boostedSpeed = 2f; // Scroll speed boosts while player is below origin
    
    // Start is called before the first frame update
    void Start()
    {
        // Find the player object and assign its transform to the playerTransform variable
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
             playerTransform = player.transform;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        float speed = normalSpeed;

        // Check if the player is below y=0
        if (playerTransform != null && playerTransform.position.y <= 0)
        {
            speed = boostedSpeed;
        }
        Debug.Log("Speed: " + speed);
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
    
}
