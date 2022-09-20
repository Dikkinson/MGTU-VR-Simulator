using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "Tasks/Wait Task")]
public class WaitTask : TaskBase
{
    [SerializeField] private float waitTime;
    public float WaitTime => WaitTime;

    public override async Task StartTask()
    {
        await base.StartTask();
        Timer timer = new Timer(waitTime);
        await timer.Start();
        MarkAsComplete();
    }
}
