using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Camera mouseCamera;
    [SerializeField] Camera rabbitCamera;
    MouseController mouseController;
    RabbitController rabbitController;
    [SerializeField] float switchCooldown = 1.0f;
    float switchTimer = 0f;

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

    void Update()
    {
        if(switchTimer >= switchCooldown)
        {
            switchPlayer();
        } else
        {
            switchTimer += Time.deltaTime;
        }
        
    }

    //Function to switch between rabbit and mouse
    void switchPlayer()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            mouseCamera.enabled = !mouseCamera.enabled;
            rabbitCamera.enabled = !rabbitCamera.enabled;
            mouseController.ActivePlayer = !mouseController.ActivePlayer;
            rabbitController.ActivePlayer = !rabbitController.ActivePlayer;
            mouseController.ResetRotation();
            rabbitController.ResetRotation();
            switchTimer = 0f;
        }
    }
}
