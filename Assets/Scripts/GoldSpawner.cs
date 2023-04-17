using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSpawner : MonoBehaviour
{
    public Transform playerTransform;

    public GameObject goldPrefab;
    public float spawnInterval;
    public float spawnHeight;
    public float spawnDistance;
    private float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        spawnHeight = -1f;
        spawnTime = Time.time + spawnInterval;

    }

    // Update is called once per frame
    void Update()
    {
        /* This is the code that is spawning the fire. */
        if (Time.time >= spawnTime)
        {
            /* Setting the spawnTime to the current time plus the spawnInterval. */
            spawnTime = Time.time + Random.Range(spawnInterval - 1f, spawnInterval + 1f);

            /* This is the code that is spawning the fire. */
            float spawnX = transform.position.x + Random.Range(-spawnDistance, spawnDistance);
            float randomDistance = Mathf.Max(spawnDistance - 1f, 10f);

            Vector3 spawnPos = new Vector3(playerTransform.position.x + randomDistance, spawnHeight, 0);


            Instantiate(goldPrefab, spawnPos, Quaternion.identity);
            Debug.Log("Spawning");
        }
    }
}
