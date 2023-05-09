using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaMoveForward : MonoBehaviour {
    private float speed = 3f; // speed of lava flow

    private void Update() {
        transform.Translate(Vector3.back * speed * Time.deltaTime); // move the lava block in the negative z direction
        if(transform.position.z <= .5f) { // stop moving the lava block when it reaches -3 units in the z direction
            speed = 0f;
        }
    }
}
