using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldedDoorController : EnvironmentController
{
    Renderer doorRender;
    BoxCollider doorCollider;

    private void Start()
    {
        doorRender = GetComponent<Renderer>();
        doorCollider = GetComponent<BoxCollider>();
    }

    public override void DoSomething()
    {
        doorRender.enabled = false;
        doorCollider.enabled = false;

    }

    public override void DoSomethingOnExit()
    {
        doorRender.enabled = true;
        doorCollider.enabled = true;
    }
}
