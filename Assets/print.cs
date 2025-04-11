using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class print : MonoBehaviour
{
    public GameObject textO; // Assign this in Inspector for each object
    public AudioSource audioSource; // Assign the corresponding AudioSource

    private bool canTrigger = false;

    void Start()
    {
        StartCoroutine(EnableTrigger());
    }

    IEnumerator EnableTrigger()
    {
        yield return new WaitForSeconds(1f);
        canTrigger = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!canTrigger) return;

        Debug.Log("Entered Trigger: " + other.gameObject.name);

        if (textO != null)
        {
            textO.SetActive(true); // Show text when entering trigger
        }

        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
            Debug.Log("Audio Playing!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited Trigger: " + other.gameObject.name);

        if (textO != null)
        {
            textO.SetActive(false); // Hide text when exiting trigger
        }

        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop(); // Stop the audio when exiting trigger
            Debug.Log("Audio Stopped!");
        }
    }
}
