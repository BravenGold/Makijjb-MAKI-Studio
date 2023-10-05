using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scorecount : MonoBehaviour {
    public TextMeshProUGUI ScoreBoard;
    public float Score = 0f;

    public void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("Made it into the second function.");
        if (collision.gameObject.CompareTag("Player")){
            Addition();
        }

    }
    void Addition(){
        Score++;
        ScoreBoard.text = "Score: "+ Score;
    }
}
