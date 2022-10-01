using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class VRButtonActionObject : ActionObject
{ 
    [SerializeField] private float pushYValue = 0.004f;

    [SerializeField] private UnityEvent onRegularPress;
    [SerializeField] private UnityEvent onTaskPress;

    private Collider buttonCollider;

    private Vector3 startPosition;
    private bool interactable = false;

    private void Awake()
    {
        startPosition = transform.localPosition;

        buttonCollider = GetComponent<Collider>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        buttonCollider.OnTriggerEnterAsObservable()
           .Where(t => t.gameObject.CompareTag("IndexFinger"))
           .Subscribe(_ =>
           {
               Pressed();
           }).AddTo(disposables);
        startPosition = transform.localPosition;

        buttonCollider.OnTriggerExitAsObservable()
            .Where(t => t.gameObject.CompareTag("IndexFinger"))
            .Subscribe(_ =>
            {
                Released();
            }).AddTo(disposables);
    }

    private void Pressed()
    {
        Vector3 newPos = startPosition;
        newPos.y -= pushYValue;
        transform.localPosition = newPos;
        onRegularPress?.Invoke();

        if (!interactable) return;

        DisableBahaviour();
    }

    private void Released()
    {
        transform.localPosition = startPosition;
    }

    protected override void BehaviourOnCall()
    {
        interactable = true;
    }

    protected override void DisableBahaviour()
    {
        onTaskPress?.Invoke();
        interactable = false;
        TaskSequenceController.NextAction.Execute();
    }
}