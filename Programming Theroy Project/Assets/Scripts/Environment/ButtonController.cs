using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    enum ButtonTypeSelector { Enter, EnterAndExit }

    [SerializeField] GameObject environmentObject;
    EnvironmentController envController;
    [SerializeField] bool repeteable = false;
    bool active = true;
    [SerializeField] ButtonTypeSelector buttonType;

    void Start()
    {
        envController = environmentObject.GetComponent<EnvironmentController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (active && (buttonType == ButtonTypeSelector.Enter || buttonType == ButtonTypeSelector.EnterAndExit))
        {
            if (!repeteable && buttonType == ButtonTypeSelector.Enter)
            {
                active = false;
            }
            envController.DoSomething();

        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (active && buttonType == ButtonTypeSelector.EnterAndExit)
        {
            if (!repeteable)
            {
                active = false;
            }
            envController.DoSomethingOnExit();

        }
    }

}
