using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] GameObject environmentObject;
    EnvironmentController envController;
    [SerializeField] bool repeteable = false;
    bool active = true;

    void Start()
    {
        envController = environmentObject.GetComponent<EnvironmentController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (active)
        {
            if (!repeteable)
            {
                active = false;
            }
            envController.DoSomething();

        }
        
    }
}
