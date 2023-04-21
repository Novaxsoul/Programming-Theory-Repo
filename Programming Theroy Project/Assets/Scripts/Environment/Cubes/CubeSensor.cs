using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSensor : MonoBehaviour
{
    CubeManager cubeManager;
    [SerializeField] GameObject assignedCube;
    // Start is called before the first frame update
    void Start()
    {
        cubeManager = GameObject.Find("Cube Manager").GetComponent<CubeManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == assignedCube)
        {
            cubeManager.SocketCube(other.gameObject);
        }
    }
}
