using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackPrefab : MonoBehaviour
{
    public string breakableTag = "Breakable";
    public float destroyDelay = 0.5f;

    private void Start()
    {
        StartCoroutine(DestroyAfterDelay());
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(breakableTag))
        {
            Destroy(collision.gameObject);
        }
    }
}