using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitController : PlayerController
{
    bool djumpReady;
    [SerializeField] float djumpForce = 3.0f;

    protected override void SpecialAbility()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isGrounded && djumpReady)
        {
            djumpReady = false;
            playerRb.velocity =  new Vector3(playerRb.velocity.x, 0, playerRb.velocity.z);
            playerRb.AddForce(Vector3.up * djumpForce, ForceMode.Impulse);
        } else
        {
            if (CheckGrounded())
            {
                djumpReady = true;
            }
        }
    }
}
