using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Singleton instance
    public static AudioManager Instance { get; private set; }

    // Dictionary to hold the audio clips
    private Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>();

    // AudioSource to play the sounds
    public AudioSource audioSource;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Load all audio clips from AudioClips array
        foreach (AudioClip clip in audioClipsArray)
        {
            audioClips.Add(clip.name, clip);
        }
    }

    // Array to hold audio clips
    public AudioClip[] audioClipsArray;

    // Play sound by name
    public void PlaySound(string soundName)
    {
        if (audioClips.ContainsKey(soundName))
        {
            audioSource.PlayOneShot(audioClips[soundName]);
        }
        else
        {
            Debug.LogWarning("Sound " + soundName + " not found!");
        }
    }
}
