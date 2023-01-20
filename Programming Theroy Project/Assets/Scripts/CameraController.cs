using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float pLerp = 0.02f;
    [SerializeField] float rLerp = 0.01f;
    // Update is called once per frame
    void LateUpdate()
    {
        MoveCamera();
        RotateCamera();
    }

    void MoveCamera()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position, pLerp);
    }

    void RotateCamera()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, player.transform.rotation, rLerp);
    }
}
