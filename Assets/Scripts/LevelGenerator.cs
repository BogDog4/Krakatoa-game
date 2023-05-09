using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject levelPrefab;
    public float levelHeight = 20f;

    private float lastLevelY = -20f;

    private void Update()
    {
        float playerY = transform.position.y;
        int currentLevel = Mathf.FloorToInt(playerY / levelHeight);

        if (currentLevel > lastLevelY / levelHeight)
        {
            float newLevelY = currentLevel * levelHeight;
            Instantiate(levelPrefab, new Vector3(0f, newLevelY - levelHeight, 0f), Quaternion.identity);
            lastLevelY = newLevelY;
        }
    }
}