using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviours : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Enemy")
        {
            // Debug.Log("Caught!");
            FindObjectOfType<GameManager>().failEndGame();
            FindObjectOfType<PlayerMovement_and_PlayerLook>().isPlayerAlive = false;

        }

        if (other.tag == "Victory")
        {
            //Debug.Log("Contact with door!");
            FindObjectOfType<GameManager>().victoryEndGame();
            FindObjectOfType<PlayerMovement_and_PlayerLook>().isPlayerAlive = false;

        }
    }
}
