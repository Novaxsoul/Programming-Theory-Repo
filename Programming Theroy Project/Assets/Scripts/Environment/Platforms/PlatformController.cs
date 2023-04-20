using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : EnvironmentController
{
    [SerializeField] float topMax = 3.0f;
    Vector3 initialPosition;

    private void Start()
    {
        initialPosition = gameObject.transform.position;
    }
    public override void DoSomething()
    {
        gameObject.transform.position = new Vector3(initialPosition.x, topMax, initialPosition.z);
    }
}
