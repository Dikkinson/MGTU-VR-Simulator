using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "Tasks/Dialogue Task")]
public class DialogueTask : TaskBase
{
    [SerializeField] private Dialogue dialogue;

    public override async Task StartTask()
    {
        await base.StartTask();
        //DialogueSystem.Instance.StartDialogue(dialogue);
        Timer timer = new Timer(dialogue.DialogueAudio.length);
        await timer.Start();
        MarkAsComplete();
    }
}
