using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    MainManager mainManager;
    // Start is called before the first frame update
    void Start()
    {
        mainManager = MainManager.Instance;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


    public void StartNewGame()
    {
        mainManager.startNewGame();
    }

    public void BackToMenu()
    {
        mainManager.LoadMenu();
    }
}

