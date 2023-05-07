using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Created by Tyler Costa 19075541

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _victoryGameOverScreen;
    [SerializeField]
    private GameObject _failGameOverScreen;
    public void victoryEndGame()
    {
        Debug.Log("Game Over! [VICTORY]");

        if (_victoryGameOverScreen != null)
        {
            _victoryGameOverScreen.SetActive(true);

        }
        else
        {
            Debug.LogError("Cant find success game over screen!");
        }
    }

    public void failEndGame()
    {
        Debug.Log("Game Over! [FAIL]");

        if(_failGameOverScreen != null)
        {
            _failGameOverScreen.SetActive(true);
        }
        else
        {
            Debug.LogError("Cant find failed game over screen!");
        }
    }
}
