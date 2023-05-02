using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    public GameObject optionPanel;
    private bool active;
    public void OpenandClose()
    {
        if(active==false)
        {
            optionPanel.gameObject.SetActive(true);
            active = true;
        }
        else
        {
            optionPanel.gameObject.SetActive(false);
            active = false;
        }
    }
    
}
