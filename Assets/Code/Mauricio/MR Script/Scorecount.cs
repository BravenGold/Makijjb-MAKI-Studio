using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scorecount : MonoBehaviour{
    public TextMeshProUGUI ScoreBoard;
    public float Score = 0f;

    public void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Player")){
            Score++;
            ScoreBoard.text = "Score: "+ Score;
        }

    }
}
