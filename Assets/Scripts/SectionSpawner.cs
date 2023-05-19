using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionSpawner : MonoBehaviour
{
    public GameObject[] sectionPrefabs; // array of section prefabs to spawn
    public Transform footerTransform; // transform of the current lowest footer
    public float spawnOffset = 1f; // distance to offset the spawned section from the footer

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Collision with Section Header!");

            // Get the index of the next section to spawn
            int sectionIndex = Random.Range(0, sectionPrefabs.Length);

            // Instantiate the next section at the position of the current lowest footer, with an offset
            Vector3 spawnPosition = footerTransform.position + Vector3.down * spawnOffset;
            Instantiate(sectionPrefabs[sectionIndex], spawnPosition, Quaternion.identity);

            // Destroy the section header
            Destroy(gameObject);
        }
    }
}