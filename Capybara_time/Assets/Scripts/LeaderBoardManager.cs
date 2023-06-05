
using UnityEngine;
using UnityEngine.UI;
using LootLocker.Requests;


public class LeaderBoardManager : MonoBehaviour
{

    public Color errorColour = Color.red;

    public InputField MemberName, PlayerScore;
    public int ID;
    public string player;
    public int score;
    public int playerFinalScore = 0;

    bool inputValid;

    public int MaxScores = 6;
    public Text[] Scores;

    //[System.Obsolete]
    public void Start()
    {
        LootLockerSDKManager.StartGuestSession("Player", (response) =>
        {
            if (response.success)
            {
                Debug.Log("Success!");

            }
            else
            {
                Debug.Log("Failed!");
            }
        });
    }

    public void ShowScores()
    {
        LootLockerSDKManager.GetScoreList(ID, MaxScores, (response) =>
        {
            if (response.success)
            {
                LootLockerLeaderboardMember[] score = response.items;
                
                for(int i =0; i <score.Length; i++)
                {
                    Scores[i].text = (score[i].rank + ". " + score[i].score + " " + score[i].member_id);
                }

            if (score.Length < MaxScores)
                {
                   for(int i = score.Length; i < MaxScores; i++)
                    {
                        Scores[i].text = (i + 1).ToString() + ".   none";
                    }
                }

            }
            else
            {
                Debug.Log("Failed!");
            }
        });
    }


    public void SubmitScore()
    {
        checkInputValidity();

        if (inputValid == true)
        {

            LootLockerSDKManager.SubmitScore(MemberName.text, int.Parse(PlayerScore.text), ID, (response) =>
            {
                if (response.success)
                {
                    Debug.Log("Success!");

                }
                else
                {
                    Debug.Log("Failed!");
                }

            });
        } else
        {
            var colours = MemberName.colors;

            colours.normalColor = errorColour;
            MemberName.colors = colours;
        }
    }

    public void setPlayerScore(int scoreRecieved)
    {
        playerFinalScore = scoreRecieved;
        PlayerScore.text = "" + playerFinalScore;

    }

    public void checkInputValidity()
    {
        string text = MemberName.text;

        if(text.Equals(""))
        {
            inputValid = false;

        } else {
            inputValid = true;
        }
    }
}
