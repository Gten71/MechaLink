using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderMusicChange : MonoBehaviour
{
    [SerializeField]
    private AudioSource music;
    [SerializeField]
    private AudioClip locationMusic;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            music.clip = locationMusic;
            music.Play();
        }
    }
}
