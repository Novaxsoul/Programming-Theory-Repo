using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class DoorController : EnvironmentController {

    // POLYMORPHISM
    public override void DoSomething()
    {
        gameObject.SetActive(false);
    
    }
}
