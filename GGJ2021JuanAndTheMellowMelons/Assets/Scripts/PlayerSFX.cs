using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    static public IEnumerator StartSFX(float playDuration, int sfxIndexPos, AudioSource audioTrack, AudioClip music)
    {   
        audioTrack.clip = music;
        audioTrack.Play();
        yield return new WaitForSeconds(playDuration);
        audioTrack.Stop();
    }
}
