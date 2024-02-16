using UnityEngine;

public class MainAudioController : MonoBehaviour
{
    public AudioSource musicAudioSource;
    public AudioSource SFXAudioSource;

    public void playMusic(AudioClip audioClip)
    {
        Debug.Log("playing");
        Debug.Log(audioClip.name);
        musicAudioSource.clip = audioClip;
        musicAudioSource.Play();
    }
    public void playSFX(AudioClip audioClip)
    {

        musicAudioSource.PlayOneShot(audioClip);
    }
}
