using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    [SerializeField] bool isBunnyOnBase = false;
    [SerializeField] bool isMouseOnBase = false;
    [SerializeField] GameObject mouseOverlay;
    [SerializeField] GameObject rabbitOverlay;
    bool levelFinished = false;

    // Update is called once per frame
    void Update()
    {
        checkLevelFinished();
    }

    void checkLevelFinished()
    {
        if(isBunnyOnBase && isMouseOnBase && !levelFinished)
        {
            levelFinished = true;
            loadNextLevel();
        }
    }

    void loadNextLevel()
    {
        MainManager.Instance.saveNextLevel();
        MainManager.Instance.LoadLevel();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bunny"))
        {
            isBunnyOnBase = true;
            rabbitOverlay.SetActive(false);
        }
        if (other.CompareTag("Mouse"))
        {
            isMouseOnBase = true;
            mouseOverlay.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bunny"))
        {
            isBunnyOnBase = false;
            rabbitOverlay.SetActive(true);
        }

        if (other.CompareTag("Mouse"))
        {
            isMouseOnBase = false;
            mouseOverlay.SetActive(true);
        }
    }
}
