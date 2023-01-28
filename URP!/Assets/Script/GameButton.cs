using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButton : MonoBehaviour
{
    PlayerMovement player;

    private void Start() {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }
    public void Restart(){
        AudioManager.instance.PitchUp("Theme");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
        AudioManager.instance.PitchUp("Theme");
        }
}
