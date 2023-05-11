using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class TimedDoorController : EnvironmentController
{
    Renderer doorRender;
    BoxCollider doorCollider;
    public bool doorActivable;
    [SerializeField]float timeToWait = 3.0f;
    public float timer;

    private void Start()
    {
        doorRender = GetComponent<Renderer>();
        doorCollider = GetComponent<BoxCollider>();
        doorActivable = true;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        ReactivateTimer();
    }

    // POLYMORPHISM
    public override void DoSomething()
    {
        if (doorActivable)
        {
            doorActivable = false;
            doorRender.enabled = false;
            doorCollider.enabled = false;
        }
    }

    void ReactivateTimer()
    {
        if (!doorActivable)
        {
            // Make the door wait to reactivate
            if (timer >= timeToWait)
            {
                doorRender.enabled = true;
                doorCollider.enabled = true;
                doorActivable = true;
                timer = 0f;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }

}
