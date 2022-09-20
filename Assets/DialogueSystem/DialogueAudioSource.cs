using UnityEngine;

public enum DialogueAudioSourceType { Phone, Speakers}

[RequireComponent(typeof(AudioSource))]
public class DialogueAudioSource : MonoBehaviour
{
    [SerializeField] private DialogueAudioSourceType audioSourceType;
    public DialogueAudioSourceType AudioSourceType => audioSourceType;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudioClip(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
