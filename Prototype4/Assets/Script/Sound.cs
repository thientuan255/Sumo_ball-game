using UnityEngine.Audio;
using UnityEngine;

//to show in the inspector
[System.Serializable]
public class Sound 
{
    public string name;

    public AudioClip clip;

    //add slider
    [Range(0f,1f)]
    public float Volumn;
    [Range(.1f, 3f)]
    public float Pitch;

    public bool loop;
    public bool playOnAwake;

    [HideInInspector]
    public AudioSource source;
}
