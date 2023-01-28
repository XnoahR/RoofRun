using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMaster : MonoBehaviour
{
    public TextMeshProUGUI TimeDisplay;
    public TextMeshProUGUI GameOver;
    public TextMeshProUGUI HighScoreText;
    public TextMeshProUGUI Score;
    PlayerMovement player;
    float timer = 3;

    private void Start() {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        player.MaxAcceleration = 0;
        GameOver.gameObject.SetActive(false);
        TimeDisplay.gameObject.SetActive(true);
        AudioManager.instance.Pitchdown("Start");

    }

    private void Update() {
        timer -= Time.deltaTime;
        TimeDisplay.text = Mathf.RoundToInt(timer).ToString();
        if(timer <= 0.6f){
            TimeDisplay.gameObject.SetActive(false);
            player.MaxAcceleration = 10;
        }
        HighScoreText.text = "HighScore: " +  Mathf.FloorToInt(PlayerPrefs.GetFloat("HighScore")).ToString();
        if(player.isAlive == false){
            GameOver.gameObject.SetActive(true);
            AudioManager.instance.Pitchdown("Theme");
        }
        Score.text = "Score : " + Mathf.FloorToInt(player.distance);
    }
    
    IEnumerator StartGame(){
        yield return new WaitForSeconds(3f);
    }

}
