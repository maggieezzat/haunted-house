using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AudioManagerScript : MonoBehaviour
{
    public AudioClip[] backgroundClips;
    public AudioSource backgroundSource;

    public AudioClip[] vampireClips;
    public AudioSource vampireSource;
    public Animator vampireAnim;

    public AudioClip[] playerClips;
    public AudioSource playerSource;
    public Animator playerAnim;
    public CinemachineVirtualCamera win;
    public Camera killBrain;



    public void playVampireBite()
    {
        vampireSource.clip = vampireClips[1];
        vampireSource.Play();
    }

    public void playDyingSound()
    {
        vampireSource.clip = vampireClips[2];
        vampireSource.Play();
    }

    public void playStabbingSound()
    {
        playerSource.clip = playerClips[0];
        playerSource.Play();
    }

    public void playTorchingSound()
    {
        playerSource.clip = playerClips[1];
        playerSource.Play();
    }

    public void playDancingMusic()
    {
        backgroundSource.clip = backgroundClips[1];
        backgroundSource.Play();
        win.Priority = 20;
    }

    public void enableKillBrain()
    {
        killBrain.enabled = true;
    }
}
