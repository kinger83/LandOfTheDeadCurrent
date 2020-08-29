using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerTest : MonoBehaviour
{

    public AudioClip clip;
    public AudioClip clipTwo;
    public AudioClip clipThree;
    // Start is called before the first frame update
    void Start()
    {
        if (AudioManager.instance)
        {
            InvokeRepeating("PlayTestOne", .8f, .8f);

          

        }
    }

    void PlayTestOne()
    {
        AudioManager.instance.PlayOneShotSound("Player", clip, transform.position, 0.5f, 0.0f, 128);
    }

    void PlayTestTwo()
    {
        AudioManager.instance.PlayOneShotSound("Zombies", clipTwo, transform.position, 0.5f, 0.0f, 100);
    }


    void PlayTestThree()
    {
        AudioManager.instance.PlayOneShotSound("Scene", clipThree, transform.position, 0.5f, 0.0f, 100);
    }
}