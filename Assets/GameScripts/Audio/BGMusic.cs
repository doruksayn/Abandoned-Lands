using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : MonoBehaviour
{
    public AudioSource backgroundM;

    public void ChangeBGM(AudioClip music){
        backgroundM.Stop();
        backgroundM.clip = music;
        backgroundM.Play();
    }
}
