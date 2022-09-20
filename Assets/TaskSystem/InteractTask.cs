using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "Tasks/Interact Task")]
public class InteractTask : TaskBase
{
    [SerializeField] private InteractableObjectReference interactableObject;
    public override Task StartTask()
    {
        interactableObject.interactableObject.Test();
        return base.StartTask();
    }
}
