using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitController : PlayerController
{
    [SerializeField] bool djumpReady;
    [SerializeField] float djumpForce = 3.0f;

    protected override void Jump()
    {
        if (shouldJump && isGrounded)
        {
            playerRb.velocity = new Vector3(playerRb.velocity.x, 0, playerRb.velocity.z);
            playerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        } else if (shouldJump && !isGrounded && djumpReady)
        {
            playerRb.velocity = new Vector3(playerRb.velocity.x, 0, playerRb.velocity.z);
            playerRb.AddForce(Vector3.up * djumpForce, ForceMode.Impulse);

            djumpReady = false;
        }
    }



    protected override void SpecialAbility()
    {

        if (CheckGrounded() && !djumpReady)
        {
            djumpReady = true;
        }
        
    }
}
