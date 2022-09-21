using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneStandActionObject : ActionObject
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void TakePhone()
    {
        if (_currentAction == actionType)
            DisableBahaviour();
    }

    protected override void BehaviourOnCall()
    {
        audioSource.Play();
    }

    protected override void DisableBahaviour()
    {
        audioSource.Stop();
        TaskSequenceController.NextAction.Execute();
    }
}
