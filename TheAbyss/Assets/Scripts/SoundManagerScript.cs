using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    [Header("------------Audio Source --------------")]
    [SerializeField]AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("------------Audio Clips -------------")]
    public AudioClip background;
    public AudioClip attack;
    public AudioClip death;
    public AudioClip enemy;
    public void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip audio) {
        sfxSource.PlayOneShot(audio);
    }
}
