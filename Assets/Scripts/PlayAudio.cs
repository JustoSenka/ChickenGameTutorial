using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public void Start()
    {
        var audioSource = gameObject.GetComponent<AudioSource>();

        if (GameManager.Instance.IsSoundOn)
            audioSource.Play();
    }

    public void Play(AudioClip clip)
    {
        var go = new GameObject();
        var audioSource = go.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();

        Destroy(go, clip.length);
    }
}
