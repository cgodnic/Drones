using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioMan : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioMan instance;

    private float musicVolume = 1f;

    // Start is called before the first frame update
    void Awake()
    {

        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        
    }

    void Start(){
        Play ("Theme");
    }

    // Update is called once per frame
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }


    public void updateVolume(float volume){
         foreach (Sound s in sounds){
            s.source.volume = volume;
        }
    }
}