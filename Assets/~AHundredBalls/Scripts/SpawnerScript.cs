using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour // A public class called SpawnerScript
{

    // Public:
    public GameObject[] prefabs = null;
    public float spawnRadius = 5.0f; // A public float called spawnRadius, which has a value of 5.0f
    public float spawnRate = 1.0f; // A public float called spawnRate, which has a value of 1.0f
    public float spawnFactor = 0.0f; // A public float called spawnFactor, which has a value of 0.0f
    // Update is called once per frame
    void Update() // A method called Update
    {
        HandleSpawn(); // Inside of the method, there is a function called HandleSpawn
	}
    // Handles spawning of objects
    void HandleSpawn() // A method called HandleSpawn
    {
        spawnFactor += Time.deltaTime; // The spawnFactor is equal to Time.deltaTime
        if (spawnFactor > spawnRate) // When the spawn factor timer reaches the interval (rate)
        {
            int randomIndex = Random.Range(0, prefabs.Length); // Get a random index into the array
            Spawn(prefabs[randomIndex]); // Spawn a random prefab from the list
            spawnFactor = 0; // Reset spawn factor (timer)
        }
    }
    // Spawns an object based off of the argument passed in "_object"
    void Spawn(GameObject _object)
    {
        GameObject newObject = Instantiate(_object); //Clone the object
        Vector3 randomPoint = Random.insideUnitCircle * spawnRadius; // Generate random spawn point
        newObject.transform.position = transform.position + randomPoint; // Set new object's position to random one
    }
}
