using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip fan, bounce, rollGround, rollSnow, fire, placement, removal, click;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(Sounds sound)
    {
        switch (sound)
        {
            case Sounds.bounce:
                audioSource.PlayOneShot(bounce);
                break;
            case Sounds.placement:
                audioSource.PlayOneShot(placement);
                break;
            case Sounds.removal:
                audioSource.PlayOneShot(removal);
                break;
            case Sounds.click:
                audioSource.PlayOneShot(click);
                break;
            default:
                break;
        }
    }

    public enum Sounds
    {
        bounce,
        placement,
        removal,
        click
    }
}
