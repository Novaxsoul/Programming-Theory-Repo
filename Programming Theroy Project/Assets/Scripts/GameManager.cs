using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Camera mouseCamera;
    [SerializeField] Camera rabbitCamera;
    MouseController mouseController;
    RabbitController rabbitController;

    // Start is called before the first frame update
    void Start()
    {
        mouseCamera.enabled = true;
        rabbitCamera.enabled = false;
        mouseController = GameObject.Find("Mouse").GetComponent<MouseController>();
        rabbitController = GameObject.Find("Rabbit").GetComponent<RabbitController>();
        mouseController.ActivePlayer = true;
        rabbitController.ActivePlayer = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        toggleCamera();
    }

    void toggleCamera()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            mouseCamera.enabled = !mouseCamera.enabled;
            rabbitCamera.enabled = !rabbitCamera.enabled;
            mouseController.ActivePlayer = !mouseController.ActivePlayer;
            rabbitController.ActivePlayer = !rabbitController.ActivePlayer;
           
        }
    }
}
