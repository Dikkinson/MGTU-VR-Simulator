using System.Threading.Tasks;
using UnityEngine;

public class TaskBase : ScriptableObject
{
    //MAYBE REMOVE-----------------------------------------------
    protected bool isCompleted;
    public bool IsCompleted => isCompleted;
    public void MarkAsComplete()
    {
        isCompleted = true;
        Debug.Log("Task Complete " + name);
    }
    public void ResetTask()
    {
        isCompleted = true;
    }
    //-------------------------------------------------------------
    public async virtual Task StartTask()
    {
        Debug.Log("Task Start " + name);
        await Task.Yield();
    }
}

