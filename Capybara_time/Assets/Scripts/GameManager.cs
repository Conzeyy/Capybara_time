using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


//Created by Tyler Costa 19075541

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _victoryGameOverScreen;
    [SerializeField]
    private GameObject _pauseMenu;

    [SerializeField]
    private GameObject _failGameOverScreen;
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

    void Start()
    {
        startTime = Time.time;
        _enemy = GameObject.FindWithTag("Enemy");
        _player = GameObject.FindWithTag("Player");
        _notHuntingUI = GameObject.FindWithTag("HuntingUI");
       

    }

    // Update is called once per frame
    void Update()
    {
              
        // Calculate the distance between the current object and the target object
        //float distance = Vector3.Distance(transform.position, _enemy.transform.position);

        // Check if the distance is within the specified range
        float distance = Vector3.Distance(_player.transform.position, _enemy.transform.position);
        

        if (distance <= distanceThreshold)
        {
            Debug.Log("Objects are within the distance threshold!");
            //play music
            //showCloseLabel(true);
            _capyCloseLabel.text = "HE IS CLOSE";
        } else
        {
            Debug.Log("Not in range");
            //stop music
            //showCloseLabel(false);

            _capyCloseLabel.text = "";


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
        /*
        //Resume
        if (Input.GetKeyDown(KeyCode.Escape) && isPauseOpen == true && issleepBetweenPresses == false)
        {
            Debug.Log("Pause menu closed");
            _pauseMenu.SetActive(false); ;
            isPauseOpen = false;
            Time.timeScale = 0f;
           // StartCoroutine(sleepBetweenPresses());

        }*/
        //Opens info UI
        if (Input.GetKeyDown(KeyCode.F5) && isDebugOn == false && issleepBetweenPresses == false)
        {
            Debug.Log("Debug Screen open");
            isDebugOn = true;
            _debugUI.SetActive(true);
          // StartCoroutine(sleepBetweenPresses());

        }

        if (Input.GetKeyDown(KeyCode.F5) && isDebugOn == true && issleepBetweenPresses == false)
        {
            Debug.Log("Debug Screen closed");
            isDebugOn = false;
            _debugUI.SetActive(false);
            StartCoroutine(sleepBetweenPresses());

        }

        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        _framesCounter.text = fps + " fps";
        _tickCounter.text = "Tick: "+ tick++;
        float elapsedTime = Time.time - startTime;

        _timer.text = "Time: " + elapsedTime;


    }

    public void showCloseLabel(bool state)
    {
        if(state == true)
        {
            StartCoroutine(textFlash());
        } else
        {
            StopCoroutine(textFlash());
        }
    }

    private void LateUpdate()
    {
        fps = Mathf.RoundToInt(1.0f / deltaTime);
        //Debug.Log("FPS: " + fps);
    }

    private IEnumerator sleepBetweenPresses()
    {
        issleepBetweenPresses = true;
        yield return new WaitForSeconds(.1f); 
        issleepBetweenPresses = false;
    }
    private IEnumerator textFlash()
    {
        //_capyCloseLabel.SetActive(true);
        yield return new WaitForSeconds(.1f);
       // _capyCloseLabel.SetActive(false);

    }

    public void pause()
    {
        //pause
        _pauseMenu.SetActive(true);
        _notHuntingUI.SetActive(false);
        stopCameraLook(false);
        Time.timeScale = 0f;
        isPauseOpen = true;
    }

    public void resume()
    {
        _pauseMenu.SetActive(false);
        _notHuntingUI.SetActive(true);

        //resume
        Time.timeScale = 1f;
        isPauseOpen = false;
        //hideUI();
        stopCameraLook(true);
    }
}
