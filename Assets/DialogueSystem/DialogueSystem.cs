using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Linq;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private Text dialogueSubtitlesText;
    [SerializeField] private DialogueAudioSource[] dialogueAudioSources;

    public static DialogueSystem Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        SetupAudioSources(dialogue.AudioSourceType, dialogue.DialogueAudio);
        dialogueSubtitlesText.text = dialogue.DialogueText;
    }

    private void SetupAudioSources(DialogueAudioSourceType audioSourceType, AudioClip audioClip)
    {
        foreach (var source in FindRequaredAudioSource(audioSourceType))
        {
            source.PlayAudioClip(audioClip);
        } 
    }

    private IEnumerable<DialogueAudioSource> FindRequaredAudioSource(DialogueAudioSourceType audioSourceType)
    {
        return dialogueAudioSources.Where(type => type.AudioSourceType == audioSourceType).Select(type => type);
    }



    /*//temp
    public Dialogue[] dialogues;
    int current = 0;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartDialogue(dialogues[current]);
            current++;
        }
    }*/

}
