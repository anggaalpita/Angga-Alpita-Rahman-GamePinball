using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgmAudioSource;
    public AudioSource bumperSFXPrefab; 
    public AudioSource switchSFXPrefab; 

    private void Start()
    {
        PlayBGM();
    }

    public void PlayBGM()
    {
        bgmAudioSource.Play();
    }

    public void PlaySFX(SFXType sfxType, Vector3 position)
    {
        AudioSource sfxAudioSourcePrefab = null;

        
        if (sfxType == SFXType.Bumper)
        {
            sfxAudioSourcePrefab = bumperSFXPrefab;
        }
        else if (sfxType == SFXType.Switch)
        {
            sfxAudioSourcePrefab = switchSFXPrefab;
        }

        if (sfxAudioSourcePrefab != null)
        {
            
            AudioSource sfxAudioSource = Instantiate(sfxAudioSourcePrefab, position, Quaternion.identity);
            Destroy(sfxAudioSource.gameObject, sfxAudioSource.clip.length); 
        }
    }
}

public enum SFXType
{
    Bumper,
    Switch
}