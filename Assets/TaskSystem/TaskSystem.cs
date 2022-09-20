using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TaskSystem : MonoBehaviour
{
    [SerializeField] private TaskBase[] tasks;

    private async void Start()
    {
        await StartTaskSequence();
    }

    private async Task StartTaskSequence()
    {
        for (int i = 0; i < tasks.Length; i++)
        {
            await tasks[i].StartTask();
        }
    }
}
