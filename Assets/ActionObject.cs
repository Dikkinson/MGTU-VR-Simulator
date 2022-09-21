using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public abstract class ActionObject : MonoBehaviour
{
    [SerializeField] protected Actions actionType;
    protected Actions _currentAction;
    public Actions ActionType => actionType;


    private CompositeDisposable disposables = new CompositeDisposable();

    private void OnEnable()
    {
        TaskSequenceController.currentAction.Subscribe(currentAction =>
        {
            _currentAction = currentAction;
            if (currentAction == actionType)
                BehaviourOnCall();
        }).AddTo(disposables);
    }

    private void OnDisable()
    {
        disposables.Clear();
    }

    protected abstract void BehaviourOnCall();

    protected abstract void DisableBahaviour();
}
