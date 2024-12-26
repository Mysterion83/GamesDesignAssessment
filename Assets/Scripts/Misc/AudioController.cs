using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    AudioSource Audio;
    [SerializeField]
    AudioClip[] Clips;
    // Start is called before the first frame update
    void Start()
    {
        Audio = GetComponent<AudioSource>();
    }
    public void Play(int ClipID, float Vol, float Pitch)
    {
        Audio.clip = Clips[ClipID];
        Audio.volume = Vol;
        Audio.pitch = Pitch;

        Audio.Play();
    }
    public void Stop()
    {
        Audio.Stop();
    }
}
