using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderAmbience : MonoBehaviour
{
    [SerializeField]
    private AudioSource ambience;
    [SerializeField]
    private AudioClip locationAmbience;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ambience.clip = locationAmbience;
            ambience.Play();
        }
    }
}
