using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    PlayerMovement player;
    int CurrScore;
    public static int Highscore;
    TextMeshProUGUI ScoreScreen;

    private void Start() {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        ScoreScreen = GetComponent<TextMeshProUGUI>();
            ScoreScreen.gameObject.SetActive(true);
    }

    private void Update() {
        CurrScore = Mathf.FloorToInt(player.distance);
        ScoreScreen.text = CurrScore.ToString();

        if(player.isAlive == false){
            ScoreScreen.gameObject.SetActive(false);
        }
    }
}
