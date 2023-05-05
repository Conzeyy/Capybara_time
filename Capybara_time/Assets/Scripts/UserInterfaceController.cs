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
    private TextMeshProUGUI _TimeText;
    private TextMeshProUGUI _objectiveText;

    //public Animator enemyAnimator;
    public GameObject enemy;

    //private PatrolState patrolState;

    // Start is called before the first frame update
    void Start()
    {
        

        _ScoreText.text = "Food collected: " + 0;
         enemy = GameObject.FindWithTag("Enemy");

    }

    public void updateText()
    {
        
    }

    public void UpdateScore(int playerScore)
    {
        _ScoreText.text = "Food collected: " + playerScore;
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
