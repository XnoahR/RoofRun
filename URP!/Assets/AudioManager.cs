using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] Musics;

    public static AudioManager instance;
    
    private void Awake() {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else{
            Destroy(this.gameObject);
        }

        foreach(Sound s in Musics){
           s.source = gameObject.AddComponent<AudioSource>();
           s.source.clip = s.clip;
           s.source.volume = s.Volume;
           s.source.pitch = s.Pitch;
           s.source.loop = s.loop;
        }
    }

    private void Start() {
        Play("Theme");
    }
    public void Play(string name){
        Sound M = Array.Find(Musics, m => m.name == name);
        if(M== null) 
        return;
        M.source.Play();
    }

    public void Mute(string name){
        Sound M = Array.Find(Musics, m => m.name == name);
        if(M == null)
        return;

        M.source.mute = true;
    }
    public void Unmute(string name){
        Sound M = Array.Find(Musics, m => m.name == name);
        if(M == null)
        return;

        M.source.mute = false;
    }

    public void Pitchdown(string name){
        Sound M = Array.Find(Musics, m => m.name == name);
        if(M == null)
        return;

        M.source.pitch = 0.5f;
    }

    public void PitchUp(string name){
        Sound M = Array.Find(Musics, m => m.name == name);
        if(M == null)
        return;

        M.source.pitch = 1f;
    }
}
