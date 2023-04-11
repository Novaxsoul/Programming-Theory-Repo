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
    Rigidbody elevatorRB;
    ElevatorSensor eSensor;

    private void Start()
    {
        elevatorRB = GetComponent<Rigidbody>();
        eSensor = GameObject.Find("ElevatorSensor").GetComponent<ElevatorSensor>();
    }

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
                Vector3 moveT = Vector3.MoveTowards(transform.position, maxFloor.position, speed * Time.deltaTime);
                elevatorRB.MovePosition(moveT);
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
                Vector3 moveT = Vector3.MoveTowards(transform.position, floor.position, speed * Time.deltaTime);
                elevatorRB.MovePosition(moveT);
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


    private void OnCollisionEnter(Collision other)
    {
        if ((other.gameObject.CompareTag("Mouse") && eSensor.mouseIsAtBase) || (other.gameObject.CompareTag("Rabbit") && eSensor.rabbitIsAtBase))
        {
            movingUp = true;
        }
    }

}
