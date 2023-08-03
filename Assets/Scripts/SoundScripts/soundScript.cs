using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundScript : MonoBehaviour
{
    public static soundScript instance;

    public AudioSource[] soundEffects;

    private void Awake()
    {
        instance= this;
    }

    public void playSoundEffect(int whichSound)
    {
        soundEffects[whichSound].Stop();
        soundEffects[whichSound].Play();
    }

    public void playRandomSoundEffect(int whichSound)
    {
        soundEffects[whichSound].Stop();
        soundEffects[whichSound].pitch=Random.Range(0.08f, 1.3f);

        soundEffects[whichSound].Play();
    }


}
