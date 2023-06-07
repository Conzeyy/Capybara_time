using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    public GameObject foodTrays;
    public GameObject key;

    private int numberOfKeys = 10;
    private int numberOfFoods = 100; 
    private float _spawnRange = 70f;

    private void Start()
    {
        //foodTrays = GameObject.FindWithTag("FoodTray");
        spawnFoodTrays();
        spawnKeys();
    }

    public void spawnKeys()
    {
        for (int i = 0; i < numberOfKeys; i++)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            Instantiate(key, spawnPosition, Quaternion.identity);
        }
    }

    private void spawnFoodTrays()
    {
        for (int i = 0; i < numberOfFoods; i++)
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
