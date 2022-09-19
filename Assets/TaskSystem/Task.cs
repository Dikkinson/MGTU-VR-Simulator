using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : TaskBase
{
    public bool MyProperty { get; set; }

    public override void MarkAsComplete()
    {
        throw new System.NotImplementedException();
    }

    public override void ResetTask()
    {
        throw new System.NotImplementedException();
    }
}
