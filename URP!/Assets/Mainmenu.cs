using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Mainmenu : MonoBehaviour
{
  

  private void Start() {
   AudioManager.instance.PitchUp("Theme");
  }
  public void StartButton(){
    SceneManager.LoadScene("Gameplay");
  }

  public void QuitButton(){
    Application.Quit();
  }

  public void MuteButton(){
    AudioManager.instance.Mute("Theme");
  }
  public void UnmuteButton(){
    AudioManager.instance.Unmute("Theme");
  }
  public void pitchup(){
  AudioManager.instance.PitchUp("Theme");
  }
  public void pitchdown(){
  AudioManager.instance.Pitchdown("Theme");
  }
}
