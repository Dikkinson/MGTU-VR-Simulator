using System.Linq;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DialogueAudioSource : MonoBehaviour
{
    [SerializeField] private Actions[] onWhatAactions;

    private AudioSource audioSource;

    private CompositeDisposable disposable = new CompositeDisposable();

    private void OnEnable()
    {
        DialogueSystem.StartDialogue.Subscribe(dialogue =>
        {
            if (onWhatAactions.Contains(dialogue.Action))
            {
                audioSource.Stop();
                audioSource.PlayOneShot(dialogue.DialogueAudio);
            }            
        }).AddTo(disposable);
        DialogueSystem.StopDialogue.Subscribe(_ =>
        {
            audioSource.Stop();
        }).AddTo(disposable);
    }

    private void OnDisable()
    {
        disposable.Clear();
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
}
