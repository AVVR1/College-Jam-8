using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PressurePlate : MonoBehaviour
{
    public static event Action onStateSwitch;
    AudioSource audioSource;
    [SerializeField] AudioClip clip;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(clip);
            onStateSwitch?.Invoke();
        }
    }
}
