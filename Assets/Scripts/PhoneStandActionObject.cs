using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PhoneStandActionObject : ActionObject
{
    private AudioSource audioSource;
    private bool isSetuped = false;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void TakePhone()
    {
        if (_currentAction == actionType)
        {
            if (isSetuped)
                DisableBahaviour();
            else
                isSetuped = true;         
        }
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
