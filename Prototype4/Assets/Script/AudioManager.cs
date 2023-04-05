using UnityEngine.Audio;
using UnityEngine;
using System;



//main idea of this script is a list of sound, that can be added or removed, each sound has property,
//each sound  has tiheir source

//create a seperate sound class to store data in each sound
public class AudioManager : MonoBehaviour

    
{
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake() //awake to play sound in the start
    {
        foreach ( Sound s in sounds)
        {
            s.source =  gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.Volumn;
            s.source.pitch = s.Pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }
    }


    public void Play (string name)
    {
        // find sound in sound array base on its name
       Sound s =  Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
