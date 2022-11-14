using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicControl : MonoBehaviour
{
    [SerializeField] private AudioClip gameMusic;
    [SerializeField] private AudioClip menuMusic;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().name == "MainMenu")
            PlayMusicManager(2);
        else
            PlayMusicManager(1);

    }

    private void PlayMusicManager(int song)
    {
        switch (song)
        {
            case 1:
                audioSource.clip = gameMusic;
                break;
            case 2:
                audioSource.clip = menuMusic;
                break;
        }
        audioSource.Play();
    }
}
