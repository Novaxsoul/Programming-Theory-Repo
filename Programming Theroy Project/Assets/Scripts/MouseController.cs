using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : PlayerController
{
    float speedMult = 1.7f;
    float baseSpeed = 4.0f;

    protected override void SpecialAbility()
    {
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            Speed = baseSpeed * speedMult;
        } else
        {
            Speed = baseSpeed; 
        }
    }
}
