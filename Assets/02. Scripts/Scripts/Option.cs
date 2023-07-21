using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    public GameObject ESC;
    public GameObject optionPanel;
    public void OpenandClose()
    {
        optionPanel.SetActive(false);
        ESC.SetActive(true);
    }

    public void StopGame()
    {
        Application.Quit();
    }
    
}
