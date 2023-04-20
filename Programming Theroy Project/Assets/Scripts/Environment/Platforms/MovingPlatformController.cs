using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : EnvironmentController
{
    [SerializeField] bool isActive = false;
    [SerializeField] bool switchFlag = true;
    [SerializeField] bool haveSensor = true;
    [SerializeField] float speed = 1f;
    float timer = 0f;
    [SerializeField] float timeToWait = 3.0f;
    [SerializeField] Transform min, max;
    Rigidbody elevatorRB;
    [SerializeField] GameObject platformSensor;
    PlatformSensor pSensor;

    private void Start()
    {
        elevatorRB = GetComponent<Rigidbody>();
        if (haveSensor)
        {
            pSensor = platformSensor.GetComponent<PlatformSensor>();
        }
        
    }

    private void FixedUpdate()
    {
        if (isActive)
        {
            elevatorSequence();
        }
    }

    public override void DoSomething()
    {
        isActive = true;
    }

    void elevatorSequence()
    {

        if (switchFlag)
        {
            if (transform.position != max.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, max.position, speed * Time.deltaTime);
                //elevatorRB.MovePosition(moveT);
            }
            else
            {
                // Make the elevator wait on max
                if (timer >= timeToWait)
                {
                    timer = 0f;
                    switchFlag = false;
                } else
                {
                    timer += Time.deltaTime;
                }
                
            }

        }
        else
        {
            if (transform.position != min.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, min.position, speed * Time.deltaTime);
                //elevatorRB.MovePosition(moveT);
            }
            else
            {
                // Make the elevator wait on min
                if (timer >= timeToWait)
                {
                    timer = 0f;
                    switchFlag = true;
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
        if (haveSensor)
        {
            if ((other.gameObject.CompareTag("Mouse") && pSensor.mouseIsAtBase) || (other.gameObject.CompareTag("Rabbit") && pSensor.rabbitIsAtBase))
            {
                switchFlag = true;
            } else if (other.gameObject.CompareTag("Mouse") || other.gameObject.CompareTag("Rabbit"))
            {
                other.gameObject.transform.SetParent(gameObject.transform, true);
            }
        } else
        {
            if (other.gameObject.CompareTag("Mouse") || other.gameObject.CompareTag("Rabbit"))
            {
                other.gameObject.transform.SetParent(gameObject.transform, true);
            }
        }

        
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Mouse") || other.gameObject.CompareTag("Rabbit"))
        {
            other.transform.parent = null;
        }
    }

}
