using System;
using UnityEngine;

public class FruitFall : MonoBehaviour
{
    public GameObject Fruits; // Assign in the Inspector
    public GameObject FruitPrefab; // Assign in the Inspector

    private float spawnInterval = 0.25f;
    private float nextSpawnTime;


    private void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }

    private void Update()
    {
        // Check if it's time to spawn a new fruit
        if (Time.time >= nextSpawnTime)
        {
            SpawnFruit();
            nextSpawnTime = Time.time + spawnInterval;
        }
        
    }
    private void SpawnFruit()
    {
        // Instantiate the fruit prefab
        GameObject newFruit = Instantiate(FruitPrefab, transform.position, Quaternion.identity);

        // Set the new fruit as a child of the Fruits GameObject
        newFruit.transform.SetParent(Fruits.transform);
    }
}
