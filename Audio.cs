using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public void PlayAudio(AudioSource _audio)
    {
        _audio.Play();
    }
}
