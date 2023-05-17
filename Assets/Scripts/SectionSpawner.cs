using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionSpawner : MonoBehaviour
{
    public GameObject[] sectionPrefabs; // array of section prefabs to spawn
    public Transform footerTransform; // transform of the current lowest footer
    public float spawnOffset = 10f; // distance to offset the spawned section from the footer

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SectionHeader"))
        {
            Debug.Log("Collision with Section Header!");

            // get the index of the next section to spawn
            int sectionIndex = Random.Range(0, sectionPrefabs.Length);

            // instantiate the next section at the position of the current lowest footer, with an offset
            Vector3 spawnPosition = footerTransform.position + Vector3.down * spawnOffset;
            GameObject newSection = Instantiate(sectionPrefabs[sectionIndex], spawnPosition, Quaternion.identity);

            // update the current lowest footer to the footer of the newly spawned section
            footerTransform = newSection.transform.Find("sectionFooter");

            // destroy the header that was collided with
            Destroy(other.gameObject);
        }
    }
}