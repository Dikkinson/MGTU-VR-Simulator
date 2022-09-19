using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Standart Dialogue")]
public class Dialogue : ScriptableObject
{
    [SerializeField] private DialogueAudioSourceType audioSourceType;
    public DialogueAudioSourceType AudioSourceType => audioSourceType;


    [SerializeField] private AudioClip dialogueAudio;
    public AudioClip DialogueAudio => dialogueAudio;


    [SerializeField, Multiline(10)] private string dialogueText;
    public string DialogueText => dialogueText;
}
