using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Created by Tyler Costa 19075541
 */

public class MainMenu : MonoBehaviour
{

    private int _mapID;


    public void loadMap(int _inputMapID)
    {
        _mapID = _inputMapID;

        StartGame(_mapID);

    }

    public void StartGame(int mapID)
    {

    /*
     * Map IDs:
     * 0 = Main menu
     * 1 = Connors Map
     * 2 = Tylers Map
     * 3 = Jaydens Map
     * 4 = Nghias Map
     */
     SceneManager.LoadScene(mapID);

    

}
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
   
}
