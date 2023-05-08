using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Created by Tyler Costa 19075541
 */
public class PlayerBehaviours : MonoBehaviour
{
    [SerializeField]
    private int foodCollected = 0;

    [SerializeField]
    private UserInterfaceController _UIManager;

    bool hasKey = false;

    private GameObject _key;

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

        if (other.tag == "Key")
        {
            Debug.Log("KEY Collected!");
            FindAnyObjectByType<AudioPlayer>().keyCollected();
            hasKey = true;
            changeObjective(hasKey);
           
            
        }

        if (other.tag == "FoodTray")
        {
            Debug.Log("Food Tray");
            FindAnyObjectByType<AudioPlayer>().foodTrayCollected();
            foodCollected++;

            // FindAnyObjectByType<>
            AddScore(foodCollected);
        }
    
    }

    public void changeObjective(bool hasKey)
    {
        _UIManager.updateObjectiveText(hasKey);

    }
    public void AddScore(int foodCollected)
    {
        _UIManager.UpdateScore(foodCollected);

    }
}
