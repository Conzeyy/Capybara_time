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
    private GameObject _failGameOverScreen;
    [SerializeField]
    private GameObject _debugUI;
    [SerializeField]
    private GameObject _notHuntingUI;


    bool isDebugOn = false;
    bool issleepBetweenPresses = false;
    private int fps;
    private int tick = 0;
    private float deltaTime = 0.0f;
    public float startTime;

    [SerializeField]
    private TextMeshProUGUI _framesCounter;
    [SerializeField]
    private TextMeshProUGUI _tickCounter;
    [SerializeField]
    private TextMeshProUGUI _timer;


    public void victoryEndGame()
    {
        Debug.Log("Game Over! [VICTORY]");

        if (_victoryGameOverScreen != null)
        {
            _victoryGameOverScreen.SetActive(true);
            hideUI();

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
            hideUI();
        }
        else
        {
            Debug.LogError("Cant find failed game over screen!");
        }
    }

    void hideUI()
    {
        if(_notHuntingUI != null)
        {
            _notHuntingUI.SetActive(false);
        }
        else
        {
            Debug.LogError("Cant find not Hunting UI!");
        }
    }

    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //Opens info UI
        if (Input.GetKeyDown(KeyCode.F5) && isDebugOn == false && issleepBetweenPresses == false)
        {
            Debug.Log("Debug Screen open");
            isDebugOn = true;
            _debugUI.SetActive(true);
            StartCoroutine(sleepBetweenPresses());

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

    private void LateUpdate()
    {
        fps = Mathf.RoundToInt(1.0f / deltaTime);
        Debug.Log("FPS: " + fps);
    }

    private IEnumerator sleepBetweenPresses()
    {
        issleepBetweenPresses = true;
        yield return new WaitForSeconds(.1f);  // Adjust the delay duration as needed
        issleepBetweenPresses = false;
    }

}
