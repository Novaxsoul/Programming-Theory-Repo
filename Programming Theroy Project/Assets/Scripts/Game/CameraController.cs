using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float pLerp = 0.02f;
    [SerializeField] float rLerp = 0.01f;
    // LateUpdate is used so the camera dont start to have weird moves
    void LateUpdate()
    {
        MoveCamera();
        RotateCamera();
    }

    // Function to move the camera according to player position
    void MoveCamera()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position, pLerp);
    }
    // Function to rotate the camera according to player rotation
    void RotateCamera()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, player.transform.rotation, rLerp);
    }
}
