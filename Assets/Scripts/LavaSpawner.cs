using UnityEngine;

public class LavaSpawner : MonoBehaviour {
    public GameObject lavaPrefab; // reference to the lava prefab
    public float spawnInterval = 1f; // time interval between spawning lava blocks
    private float spawnTimer = 0f; // timer to track spawning time

    private void Update() {
        spawnTimer += Time.deltaTime; // increment the spawn timer by the elapsed time
        if(spawnTimer >= spawnInterval) { // check if it's time to spawn a new lava block
            SpawnLava(); // call the SpawnLava() function
            spawnTimer = 0f; // reset the spawn timer
        }
    }

    private void SpawnLava() {
        // generate random x and y positions within 10 units of the player
        float x = Random.Range(transform.position.x - 10f, transform.position.x + 10f);
        float y = Random.Range(transform.position.y - 10f, transform.position.y + 10f);
        Vector3 spawnPosition = new Vector3(x, y, 5f); // set the spawn position with the random x, y, and fixed z coordinates
        Instantiate(lavaPrefab, spawnPosition, Quaternion.identity); // instantiate the lava prefab at the spawn position with no rotation
    }
}