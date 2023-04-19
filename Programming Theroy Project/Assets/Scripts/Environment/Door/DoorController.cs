using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : EnvironmentController { 
    public override void DoSomething()
    {
        gameObject.SetActive(false);
    
    }
}
