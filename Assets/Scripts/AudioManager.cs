using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    AudioSource speaker;

    [SerializeField]
    AudioClip _gunShot;
    [SerializeField]
    AudioClip _reload;
    [SerializeField]
    AudioClip _boom;
    void Awake()
    {
      speaker = GetComponent<AudioSource>();
    }

    public void PlayGunShot()
    {
        speaker.clip = _gunShot;
        speaker.Play();
    }

    public void PlayReload()
    {
        speaker.clip = _reload;
        speaker.Play();
    }
    public void PlayExplode()
    {
        speaker.clip = _boom;
        speaker.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
