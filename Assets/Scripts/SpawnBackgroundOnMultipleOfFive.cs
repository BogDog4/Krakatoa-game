using UnityEngine;

public class SpawnBackgroundOnMultipleOfTen : MonoBehaviour
{
    public GameObject backgroundPrefab;
    private float lastMultipleOfTen = -10f;

    private void Update()
    {
        // Check if the player's y position is a multiple of 10
        float playerY = transform.position.y;
        float nearestMultipleOfTen = Mathf.Round(playerY / 10f) * 10f;
        if (nearestMultipleOfTen < lastMultipleOfTen)
        {
            lastMultipleOfTen = nearestMultipleOfTen;

            // Instantiate the background prefab at (0, nearestMultipleOfTen + 5, 4)
            Vector3 spawnPosition = new Vector3(0f, nearestMultipleOfTen -10f, 4f);
            Instantiate(backgroundPrefab, spawnPosition, Quaternion.identity);
        }
    }
}