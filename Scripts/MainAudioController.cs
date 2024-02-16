using UnityEngine;

public class MainAudioController : MonoBehaviour
{
    public AudioSource musicAudioSource;
    public AudioSource SFXAudioSource;

    public void playMusic(AudioClip audioClip)
    {
        musicAudioSource.Stop();
        musicAudioSource.clip = audioClip;
        musicAudioSource.Play();
    }
    public void playSFX(AudioClip audioClip)
    {
        musicAudioSource.PlayOneShot(audioClip);
    }
}
