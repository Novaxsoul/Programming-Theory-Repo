using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public bool isSocketed;
    public Vector3 defaultPosition;


    // Start is called before the first frame update
    void Start()
    {
        isSocketed = false;
        defaultPosition = transform.position;
    }

}
