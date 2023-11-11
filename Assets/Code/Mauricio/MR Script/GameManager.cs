using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text ScoreText;
    public int Score = 1;
    public int maxScore;

    public GameObject Youtext;

    void start(){
        Score = 0;
    }
    public void AddScore(int newScore){
        Score+=newScore;
    }

    public void UpdateScore(){
        ScoreText.text = "Score: "+Score + "\nGoal: " +maxScore;
    }
    void Update(){
        UpdateScore();
        if(Score==maxScore){
            Youtext.SetActive(true);
        }
    }
}
