using UnityEngine;
using System.Collections;

public class PlayRandomSound : MonoBehaviour {

    AudioSource src;

    [Header("Audio Clips")]
    public AudioClip[] audioClips;
    
    [Header("Pitch")]
    public bool randomPitch = true;
    public float minPitch = 0.85f;
    public float maxPitch = 1.2f;

    [Header("Autodestruction")]
    public bool autodestruct = true;
    public float seconds = 2f;
	
	void Start () {
        src = GetComponent<AudioSource>();

        if (randomPitch)
            src.pitch = Random.Range(minPitch, maxPitch);

        int i = Random.Range(0, audioClips.Length);

        src.PlayOneShot(audioClips[i]);

        Destroy(this.gameObject, seconds);
	}
}
