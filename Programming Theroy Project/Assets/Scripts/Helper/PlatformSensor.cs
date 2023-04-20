using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSensor : MonoBehaviour
{
    public bool mouseIsAtBase;
    public bool rabbitIsAtBase;

    private void Start()
    {
        mouseIsAtBase = false;
        rabbitIsAtBase = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mouse"))
        {
            mouseIsAtBase = true;
        } 
        if (other.CompareTag("Rabbit"))
        {
            rabbitIsAtBase = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Mouse"))
        {
            mouseIsAtBase = false;
        }
        if (other.CompareTag("Rabbit"))
        {
            rabbitIsAtBase = false;
        }
    }
}
