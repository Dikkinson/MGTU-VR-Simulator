using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TMPro;

[System.Serializable]
public enum Actions { PhoneRing, Dialogue, PressButton1, PressButton2, PressButton3, PressButton4, PressButton5, PressButton6, PressButton7, Empty, PGS }

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
            if (currentActionId < actionSequence.Length)
            {
                currentActionId++;
                currentAction.Value = actionSequence[currentActionId];
                Debug.Log(currentAction.Value);
            }          
        }).AddTo(disposables);

        currentAction.Value = actionSequence[currentActionId];
    }

    private void OnDisable()
    {
        disposables.Clear();
    }
}
