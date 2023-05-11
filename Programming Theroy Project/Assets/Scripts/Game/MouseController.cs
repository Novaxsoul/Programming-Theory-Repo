using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class MouseController : PlayerController
{
    float speedMult = 1.7f;
    float baseSpeed = 4.0f;

    // Mouse dash ability
    // POLYMORPHISM
    protected override void SpecialAbility()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = baseSpeed * speedMult;
        } else
        {
            Speed = baseSpeed; 
        }
    }
}
