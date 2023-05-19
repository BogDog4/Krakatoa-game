using UnityEngine;

public class LavaSpawner : MonoBehaviour {
    public GameObject lavaPrefab; // reference to the lava prefab
    public float spawnInterval = .25f; // time interval between spawning lava blocks
    private float spawnTimer = 0f; // timer to track spawning time

    private void Update() {
        spawnTimer += Time.deltaTime; // increment the spawn timer by the elapsed time
        if (spawnTimer >= spawnInterval) { // check if it's time to spawn a new lava block
            SpawnLava(); // call the SpawnLava() function
            spawnTimer = 0f; // reset the spawn timer
        }
    }

    private void SpawnLava() {
        // generate random x and y positions
        float x = Random.Range(transform.position.x - 8f, transform.position.x + 8f);
        float y = Random.Range(transform.position.y - 1f, transform.position.y + 8f);

        // Round the positions to the nearest whole number
        x = Mathf.Round(x);
        y = Mathf.Round(y);

        Vector3 spawnPosition = new Vector3(x, y, 5f); // set the spawn position with the rounded x, y, and fixed z coordinates
        Instantiate(lavaPrefab, spawnPosition, Quaternion.identity); // instantiate the lava prefab at the spawn position with no rotation
    }
}