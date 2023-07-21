using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESC : MonoBehaviour
{
    public GameObject ESCPanel;
    public GameObject OptionPanel;
    public GameObject EX;
    public GameObject BG;

    void Update()
    {
        InputESC();
    }

    private void InputESC()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ESCPanel.activeSelf)
            {
                BG.SetActive(false);
                ESCPanel.SetActive(false);
                return;
            }
            else if (OptionPanel.activeSelf || EX.activeSelf)
            {
                OptionPanel.SetActive(false);
                EX.SetActive(false);
                ESCPanel.SetActive(true);
                return;
            }
            BG.SetActive(true);
            ESCPanel.SetActive(true);
        }
    }
}
