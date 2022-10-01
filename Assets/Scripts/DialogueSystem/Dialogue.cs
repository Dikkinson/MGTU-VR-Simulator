using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Standart Dialogue")]
public class Dialogue : ScriptableObject
{
    [SerializeField] private Actions action;
    public Actions Action => action;

    [SerializeField] private AudioClip dialogueAudio;
    public AudioClip DialogueAudio => dialogueAudio;


    [SerializeField, Multiline(10)] private string dialogueText;
    public string DialogueText => dialogueText;
}
