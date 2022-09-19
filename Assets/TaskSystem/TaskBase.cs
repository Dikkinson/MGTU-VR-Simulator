using UnityEngine;

public abstract class TaskBase : MonoBehaviour
{
    protected bool isCompleted;
    public bool IsCompleted => isCompleted;
    public abstract void MarkAsComplete();
    public abstract void ResetTask();
}

