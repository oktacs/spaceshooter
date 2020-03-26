using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerController : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVol", Mathf.Log10(volume) * 20);
    }
    public void SetSfxVolume(float volume)
    {
        audioMixer.SetFloat("sfxVol", volume);
    }

}
