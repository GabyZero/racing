using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Set music volume as in the playerprefs at the beginning
 **/
[RequireComponent(typeof(AudioSource))]
public class SetMusicVolume : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume"); 
    }

}
