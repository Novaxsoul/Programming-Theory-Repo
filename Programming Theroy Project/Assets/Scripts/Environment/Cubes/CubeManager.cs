using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class CubeManager : EnvironmentController
{
    [SerializeField] GameObject[] cubes;
    [SerializeField] GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SocketCube(GameObject cubeToCheck)
    {
        foreach (GameObject cube in cubes)
        {
            if(cube == cubeToCheck)
            {
                cubeToCheck.GetComponent<CubeController>().isSocketed = true;
                break;
            }
        }

        if (CheckCubes())
        {
            Debug.Log("Todos los cubos ok");
            door.SetActive(false);
        }

    }

    bool CheckCubes()
    {
        foreach (GameObject cube in cubes)
        {
            bool cubeSocketed = cube.GetComponent<CubeController>().isSocketed;
            if (!cubeSocketed)
            {
                return false;
            }
        }

        return true;
    }

    // POLYMORPHISM
    public override void DoSomething()
    {
        foreach (GameObject cube in cubes)
        {
            CubeController cubeController = cube.GetComponent<CubeController>();
            if (!cubeController.isSocketed)
            {
                cube.transform.position = cubeController.defaultPosition;
            }
        }
    }
}
