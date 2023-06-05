using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject enemyObject;
    // Start is called before the first frame update
    void Start()
    {
        enemyObject = GameObject.Find("Enemy");
        //Sets enemy to true because victory screens and end screens deactivate enemy
        enemyObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
