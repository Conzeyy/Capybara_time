using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    public GameObject foodTrays; // The prefab of the object you want to spawn
    public int numberOfObjects = 500; // The number of objects to spawn
    private float _spawnRange = 40f; // The range within which objects will spawn

    private void Start()
    {
        //foodTrays = GameObject.FindWithTag("FoodTray");
        spawnFoodTrays();
    }

    private void spawnFoodTrays()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            Instantiate(foodTrays, spawnPosition, Quaternion.identity);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float x = Random.Range(-_spawnRange, _spawnRange);
        float z = Random.Range(-_spawnRange, _spawnRange);
        return new Vector3(x, 0f, z);
    }
}
