using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : EnvironmentController
{
    bool elevatorActive = false;
    [SerializeField] Transform floor, maxFloor;
    bool movingUp = true;
    [SerializeField] float speed = 1f;
    float timer = 0f;
    float timeToWait = 3.0f;

    private void FixedUpdate()
    {
        if (elevatorActive)
        {
            elevatorSequence();
        }
    }

    public override void DoSomething()
    {
        elevatorActive = true;
    }

    void elevatorSequence()
    {

        if (movingUp)
        {
            if (transform.position != maxFloor.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, maxFloor.position, speed * Time.deltaTime);
            }
            else
            {
                // Make the elevator wait on maxfloor
                if (timer >= timeToWait)
                {
                    timer = 0f;
                    movingUp = false;
                } else
                {
                    timer += Time.deltaTime;
                }
                
            }

        }
        else
        {
            if (transform.position != floor.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, floor.position, speed * Time.deltaTime);
            }
            else
            {
                // Make the elevator wait on floor
                if (timer >= timeToWait)
                {
                    timer = 0f;
                    movingUp = true;
                }
                else
                {
                    timer += Time.deltaTime;
                }
            }
        }
        
     
    }

}
