using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TMPro;

[System.Serializable]
public enum Actions { PhoneRing, Dialogue, PressButtn, }

public class TaskSequenceController : MonoBehaviour
{
    [SerializeField] private Actions[] actionSequence;

    public readonly static ReactiveProperty<Actions> currentAction = new ReactiveProperty<Actions>();
    public readonly static ReactiveCommand NextAction = new ReactiveCommand();
    private int currentActionId = 0;

    private CompositeDisposable disposables = new CompositeDisposable(); 

    private void OnEnable()
    {
        NextAction.Subscribe(_ =>
        {
            Debug.Log("next");
            currentActionId++;
            currentAction.Value = actionSequence[currentActionId];
        }).AddTo(disposables);

        currentAction.Value = actionSequence[currentActionId];
    }

    private void OnDisable()
    {
        disposables.Clear();
    }

    private void Update()
    {
        Debug.Log(currentAction + " " + currentActionId);
    }
}
