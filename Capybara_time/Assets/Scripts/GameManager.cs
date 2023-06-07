using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



//Created by Tyler Costa 19075541
//Improved since code review
public class GameManager : MonoBehaviour
{
    //GameObjects accessible in Editor
    [SerializeField]
    private GameObject _victoryGameOverScreen;
    [SerializeField]
    private GameObject _pauseMenu;
    [SerializeField]
    private GameObject _failGameOverScreen;
    [SerializeField]
    private GameObject _optionsMenu;
    [SerializeField]
    private GameObject _debugUI;
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private GameObject _enemy;
    private GameObject _notHuntingUI;

    public Transform player;
    public Transform enemy;

    bool isDebugOn = false;
    bool issleepBetweenPresses = false;
    public static bool isPauseOpen = false;
    private int fps;
    private int tick = 0;
    private float deltaTime = 0.0f;
    public float startTime;
    public float distanceThreshold = 5f;
    public AudioPlayer audio;

    [SerializeField]
    private TextMeshProUGUI _framesCounter;
    [SerializeField]
    private TextMeshProUGUI _tickCounter;
    [SerializeField]
    private TextMeshProUGUI _timer;
    [SerializeField]
    private GameObject _LeaderBoard;
    [SerializeField]
    private TextMeshProUGUI _capyCloseLabel;
    [SerializeField]
    private TextMeshProUGUI _difficultyButton;
    [SerializeField]
    private GameObject _miniMap;

    public bool isGameHard = false;
    public bool isChecked;

    public void OnRadioButtonToggled(bool newState)
    {


        //Sets game difficulty to hard and disables minimap
        isGameHard = true;
        _miniMap.SetActive(false);
          
        Debug.Log("Radio button is checked");

    }


    //This code disables the enemy when called by victory and death screen functions
    public void stopEnemy()
    {

        if(_enemy != null)
        {
            _enemy.SetActive(false);
        } else
        {
            Debug.LogError("Cant find enemy object");

        }
    }
    

    
    //This shows the leaderboard
    public void showLeaderBoard()
    {
        if(_LeaderBoard != null)
        {
            _LeaderBoard.SetActive(true);
        } else
        {
            Debug.LogError("Cant find Leader board object!");
        }
    }
    //Displays the end game scene, hides player ui, disables enemy and shows leaderboard
    public void victoryEndGame()
    {
        Debug.Log("Game Over! [VICTORY]");

        if (_victoryGameOverScreen != null)
        {
            _victoryGameOverScreen.SetActive(true);
            hideUI(false);
            stopEnemy();
            showLeaderBoard();

        }
        else
        {
            Debug.LogError("Cant find success game over screen!");
        }
    }

    //Displays the end game scene, hides player ui, disables enemy and shows leaderboard

    public void failEndGame()
    {
        Debug.Log("Game Over! [FAIL]");

        if(_failGameOverScreen != null)
        {
            _failGameOverScreen.SetActive(true);
            hideUI(false);
            showLeaderBoard();
        }
        else
        {
            Debug.LogError("Cant find failed game over screen!");
        }
    }

    //Hides player UI
    void hideUI(bool state)
    {
        if(_notHuntingUI != null)
        {
            _notHuntingUI.SetActive(state);
        }
        else
        {
            Debug.LogError("Cant find not Hunting UI!");
        }
    }

    //Stops camera from moving when player is paused
    public void stopCameraLook(bool state)
    {
        if(_player != null)
        {
            PlayerMovement_and_PlayerLook playerCamera = _player.GetComponent<PlayerMovement_and_PlayerLook>();
            playerCamera.enabled = state;
        }
    }

    //gets time and instantiates player, enemy and UI objects on start
    void Start()
    {
        audio = _player.GetComponent<AudioPlayer>();
        
        startTime = Time.time;
        _enemy = GameObject.FindWithTag("Enemy");
        _player = GameObject.FindWithTag("Player");
        _notHuntingUI = GameObject.FindWithTag("HuntingUI");
       


}

// Update is called once per frame
void Update()
    {


        if (!Application.isFocused)
        {
            // Game focus is lost
            pause();

            
        }
        
        
        float distance = Vector3.Distance(_player.transform.position, _enemy.transform.position);
        
        //Displays message and plays audio
        if (distance <= distanceThreshold)
        {
            Debug.Log("Objects are within the distance threshold!");

            _capyCloseLabel.text = "HE'S ALSMOT GOT YOU!";

            audio.enemyWarning(true);
        } else
        {

         
            _capyCloseLabel.text = "";
            audio.enemyWarning(false);


        }



        //Pause
        if (Input.GetKeyDown(KeyCode.Escape) )
        {
            if (isPauseOpen)
            {
                resume();

            }
            else
            {
                pause();

            }
            Debug.Log("Pause menu opened");
           // StartCoroutine(sleepBetweenPresses());

        }

        //Opens info UI
        if (Input.GetKeyDown(KeyCode.F5) && isDebugOn == false && issleepBetweenPresses == false)
        {
            Debug.Log("Debug Screen open");
            isDebugOn = true;
            _debugUI.SetActive(true);


        }

        if (Input.GetKeyDown(KeyCode.F5) && isDebugOn == true && issleepBetweenPresses == false)
        {
            Debug.Log("Debug Screen closed");
            isDebugOn = false;
            _debugUI.SetActive(false);
            StartCoroutine(sleepBetweenPresses());

        }

        //Gets FPS
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        _framesCounter.text = fps + " fps";
        _tickCounter.text = "Tick: "+ tick++;
        float elapsedTime = Time.time - startTime;

        _timer.text = "Time: " + elapsedTime;


    }


    //This uses Unity LateUpadte to get the current fps by dividing the amount of frames by 1 second
    private void LateUpdate()
    {
        fps = Mathf.RoundToInt(1.0f / deltaTime);
        //Debug.Log("FPS: " + fps);
    }

    //Stops fps menu from opening/closing too quickly
    private IEnumerator sleepBetweenPresses()
    {
        issleepBetweenPresses = true;
        yield return new WaitForSeconds(.1f); 
        issleepBetweenPresses = false;
    }

    //handles pause menu, stops game, hides game ui and shows menu UI
    public void pause()
    {
        //pause
        _pauseMenu.SetActive(true);
        _notHuntingUI.SetActive(false);
        stopCameraLook(false);
        Time.timeScale = 0f;
        isPauseOpen = true;
    }


    //Similar system for resume()
    public void resume()
    {
        _pauseMenu.SetActive(false);
        _notHuntingUI.SetActive(true);

        Time.timeScale = 1f;
        isPauseOpen = false;
        stopCameraLook(true);
    }
}
