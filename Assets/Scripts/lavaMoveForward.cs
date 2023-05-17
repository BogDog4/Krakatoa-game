using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lavaMoveForward : MonoBehaviour {
    public float speed = 1f; // speed of lava flow
    public bool lavaIsActive;

    private void Update() {
        transform.Translate(Vector3.back * speed * Time.deltaTime); // move the lava block in the negative z direction
        if(transform.position.z <= .5f) { // stop moving the lava block when it reaches .5 in the z direction
            speed = 0f;
            lavaIsActive = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player") && lavaIsActive) {
            SceneManager.LoadScene("tryAgain"); // Load the "tryAgain" scene
        }
    }
}

