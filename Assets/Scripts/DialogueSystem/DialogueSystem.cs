using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Linq;
using UniRx;
using System;

public class DialogueSystem : ActionObject
{
    [SerializeField] private Dialogue[] dialogues;
    private int currentDialogue = 0;

    public readonly static ReactiveCommand<Dialogue> StartDialogue = new ReactiveCommand<Dialogue>();
    public readonly static ReactiveCommand StopDialogue = new ReactiveCommand();

    protected override void BehaviourOnCall()
    {
        StartDialogue.Execute(dialogues[currentDialogue]);
        Observable.Timer(TimeSpan.FromSeconds(dialogues[currentDialogue].DialogueAudio.length)).Subscribe(_ =>
        {
            DisableBahaviour();
        });
        if (currentDialogue < dialogues.Length)
            currentDialogue++;    
    }

    protected override void DisableBahaviour()
    {
        StopDialogue.Execute();
        TaskSequenceController.NextAction.Execute();
    }
}
