using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActionObject : ActionObject
{
    protected override void BehaviourOnCall()
    {
        
    }

    protected override void DisableBahaviour()
    {
        TaskSequenceController.NextAction.Execute();
    }

    public void PressButton()
    {
        if (_currentAction == actionType)
            DisableBahaviour();
    }
}
