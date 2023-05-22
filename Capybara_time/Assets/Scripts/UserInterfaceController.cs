using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Animations;
/*
 * Created by Tyler Costa 19075541
 */

public class UserInterfaceController : MonoBehaviour
{


    [SerializeField]
    private TextMeshProUGUI _ScoreText;
    [SerializeField]
    private TextMeshProUGUI _MessageText;
    [SerializeField]
    private TextMeshProUGUI _objectiveText;


    bool keyFound = false;

    // Start is called before the first frame update
    void Start()
    {
        

        _ScoreText.text = "Food collected: " + 0;


    }
    
    public void updateObjectiveText(bool hasKey)
    {
        if(hasKey == false)
        {
            //Key not found
            _objectiveText.text = "Find a key to escape!";

        } else
        {
            //key found
            
            _objectiveText.text = "Find the exit and escape!";
        }

        keyFound = hasKey;
    }

    public void updateMessageText(bool isHunting)
    {
        if (isHunting == false && keyFound == false)
        {
            _MessageText.text = "Capybara is not hunting!";
            _objectiveText.text = "Objective: Find a key to escape";
        }
        else if (isHunting == true)
        {
            _MessageText.text = "Capybara is hunting you!";

        }
    }

    public void UpdateScore(int playerScore)
    {
        _ScoreText.text = "Food collected: " + playerScore;
    }

   // public void update


}
