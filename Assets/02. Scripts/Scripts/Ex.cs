using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex : MonoBehaviour
{
    public GameObject ExPanel;
    private bool active;
    public void OpenandClose()
    {
        if (active == false)
        {
            ExPanel.gameObject.SetActive(true);
            active = true;
        }
        else
        {
            ExPanel.gameObject.SetActive(false);
            active = false;
        }
    }
}
