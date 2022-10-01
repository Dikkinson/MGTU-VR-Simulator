using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public abstract class ActionObject : MonoBehaviour
{
    [SerializeField] protected Actions actionType;
    protected Actions _currentAction;
    public Actions ActionType => actionType;


    protected CompositeDisposable disposables = new CompositeDisposable();

    protected virtual void OnEnable()
    {
        TaskSequenceController.currentAction.Subscribe(currentAction =>
        {
            _currentAction = currentAction;
            if (currentAction == actionType)
                BehaviourOnCall();
        }).AddTo(disposables);
    }

    protected void OnDisable()
    {
        disposables.Clear();
    }

    protected abstract void BehaviourOnCall();

    protected abstract void DisableBahaviour();
}
