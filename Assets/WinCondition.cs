using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WinCondition : MonoBehaviour
{
    public TextMeshProUGUI announceScore; //References to the Text GameObject displaying the score message
    public TextMeshProUGUI team1ScoreText;
    public TextMeshProUGUI team2ScoreText;
    public GameObject Team1;
    public GameObject Team2;
    int team1Score = 0;
    int team2Score = 0;
    public float displayDuration = 5f; //Duration in seconds to display the win text
    
    public void OnTriggerBrick(GameObject other)
    {
        //Get gameObject that triggered the collider
        GameObject triggeredObject = other.gameObject;
        
        //Determine score message Based off Cube touched
        string scoreMessage = "";

        //team 1
        if(triggeredObject == Team1)
        {
            scoreMessage = "Team 1 has scored!";
            team1Score +=1;
        }
        //team2
        else if(triggeredObject == Team2)
        {
            scoreMessage = "Team 2 has scored!";
            team2Score +=1;
        }
        //Enable Text
        if(scoreMessage != "") //Only show text if a score is met
        {
                    
            announceScore.text = scoreMessage;
            announceScore.gameObject.SetActive(true);
            team1ScoreText.text = "Team 1: " + team1Score;  
            team2ScoreText.text = "Team 2: " + team2Score; 
            StartCoroutine(TurnOffText());
        }
                

    }

    IEnumerator TurnOffText()
    {
        //Wait for display Duration
        yield return new WaitForSeconds(displayDuration);
        //Turn off win text
        announceScore.gameObject.SetActive(false);
    }
}
